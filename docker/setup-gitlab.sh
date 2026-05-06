#!/usr/bin/env bash
# setup-gitlab.sh — GitLab POC 快速設定腳本
# 功能：設定 root 密碼、建立專案、取得 API Token、設定 Webhook、推送程式碼
# 使用方式：bash setup-gitlab.sh
#
# 前提：docker-compose.infra.yml 已啟動，且 GitLab 已完成初始化（約 3-5 分鐘）

set -e

# ─── 設定變數 ─────────────────────────────────────────────────────────────────
GITLAB_URL="http://localhost:8929"
GITLAB_ROOT_PASSWORD="${GITLAB_ROOT_PASSWORD:-password}"
PROJECT_NAME="jenkins-sample"
JENKINS_URL="${JENKINS_URL:-http://localhost:8080}"
JENKINS_USER="${JENKINS_USER:-admin}"
JENKINS_PASSWORD="${JENKINS_PASSWORD:-admin}"

echo "🚀 GitLab POC 設定開始..."
echo ""

# ─── 1. 等待 GitLab 就緒 ──────────────────────────────────────────────────────
echo "⏳ 等待 GitLab 服務就緒（最多 5 分鐘）..."
for i in $(seq 1 60); do
  STATUS=$(curl -s -o /dev/null -w "%{http_code}" "${GITLAB_URL}/-/health" 2>/dev/null || echo "000")
  if [ "$STATUS" = "200" ]; then
    echo "✅ GitLab 已就緒！"
    break
  fi
  if [ "$i" = "60" ]; then
    echo "❌ GitLab 在 5 分鐘內未就緒，請確認容器狀態"
    exit 1
  fi
  echo "   等待中... ($i/60)"
  sleep 5
done
echo ""

# ─── 2. 設定 root 密碼並取得 Personal Access Token ───────────────────────────
echo "🔑 設定 root 密碼並建立 API Token..."

# 使用 GitLab Rails console 建立 root token（透過 docker exec）
GITLAB_TOKEN=$(docker exec gitlab gitlab-rails runner \
  "user = User.find_by_username('root');
   user.password = '${GITLAB_ROOT_PASSWORD}';
   user.password_confirmation = '${GITLAB_ROOT_PASSWORD}';
   user.save!;
   token = user.personal_access_tokens.create(name: 'jenkins-poc', scopes: ['api', 'read_repository', 'write_repository'], expires_at: 1.year.from_now);
   puts token.token" 2>/dev/null | tail -1)

if [ -z "$GITLAB_TOKEN" ]; then
  echo "⚠️  無法自動建立 Token，請手動前往 GitLab 建立："
  echo "   ${GITLAB_URL}/-/profile/personal_access_tokens"
  echo "   建立後請設定環境變數 GITLAB_API_TOKEN=<your-token> 並重新執行"
  exit 1
fi

echo "✅ GitLab API Token：${GITLAB_TOKEN}"
echo ""

# ─── 3. 建立 GitLab 專案 ──────────────────────────────────────────────────────
echo "📁 建立 GitLab 專案 '${PROJECT_NAME}'..."

CREATE_RESULT=$(curl -s -o /dev/null -w "%{http_code}" \
  -X POST "${GITLAB_URL}/api/v4/projects" \
  -H "PRIVATE-TOKEN: ${GITLAB_TOKEN}" \
  -H "Content-Type: application/json" \
  -d "{
    \"name\": \"${PROJECT_NAME}\",
    \"visibility\": \"private\",
    \"initialize_with_readme\": false,
    \"default_branch\": \"main\"
  }")

if [ "$CREATE_RESULT" = "201" ]; then
  echo "✅ 專案建立成功！"
elif [ "$CREATE_RESULT" = "400" ]; then
  echo "⚠️  專案已存在，繼續後續設定..."
else
  echo "❌ 建立專案失敗 (HTTP $CREATE_RESULT)"
  exit 1
fi
echo ""

# ─── 4. 設定 Git Remote 並推送 ────────────────────────────────────────────────
echo "📤 設定 Git Remote 並推送程式碼..."

REPO_DIR="$(cd "$(dirname "$0")/.." && pwd)"
cd "$REPO_DIR"

REMOTE_URL="http://root:${GITLAB_ROOT_PASSWORD}@localhost:8929/root/${PROJECT_NAME}.git"
REMOTE_URL_INTERNAL="http://root:${GITLAB_ROOT_PASSWORD}@gitlab:8929/root/${PROJECT_NAME}.git"

# 設定或更新 gitlab remote
if git remote get-url gitlab &>/dev/null; then
  git remote set-url gitlab "$REMOTE_URL"
  echo "✅ 已更新 gitlab remote URL"
else
  git remote add gitlab "$REMOTE_URL"
  echo "✅ 已新增 gitlab remote"
fi

# 推送當前分支到 main
CURRENT_BRANCH=$(git branch --show-current)
echo "   推送分支 '${CURRENT_BRANCH}' → GitLab main..."
git push gitlab "${CURRENT_BRANCH}:main" --force
echo "✅ 程式碼推送完成！"
echo ""

# ─── 5. 設定 Jenkins GitLab API Token ────────────────────────────────────────
echo "🔧 更新 Jenkins 環境中的 GitLab API Token..."

# 透過 Jenkins API 更新 Secret Text 憑證
UPDATE_CRED=$(curl -s -o /dev/null -w "%{http_code}" \
  -u "${JENKINS_USER}:${JENKINS_PASSWORD}" \
  -X POST "${JENKINS_URL}/credentials/store/system/domain/_/credential/gitlab-api-token/updateSubmit" \
  --data-urlencode "json={
    \"\$class\": \"org.jenkinsci.plugins.plaincredentials.impl.StringCredentialsImpl\",
    \"scope\": \"GLOBAL\",
    \"id\": \"gitlab-api-token\",
    \"secret\": \"${GITLAB_TOKEN}\",
    \"description\": \"GitLab API Token（Webhook 狀態回報使用）\"
  }" 2>/dev/null)

if [ "$UPDATE_CRED" = "200" ]; then
  echo "✅ Jenkins 憑證更新成功！"
else
  echo "⚠️  Jenkins 憑證可能需要手動更新（HTTP $UPDATE_CRED）"
  echo "   請前往 ${JENKINS_URL}/credentials 手動設定 gitlab-api-token"
fi
echo ""

# ─── 6. 取得 Jenkins Webhook Token 並設定 GitLab Webhook ─────────────────────
echo "🔗 設定 GitLab → Jenkins Webhook..."

# 取得 Jenkins job 的 GitLab Webhook token
WEBHOOK_TOKEN=$(curl -s \
  -u "${JENKINS_USER}:${JENKINS_PASSWORD}" \
  "${JENKINS_URL}/job/jenkins-sample/config.xml" 2>/dev/null | \
  grep -oP '(?<=<secretToken>)[^<]+' || echo "")

if [ -z "$WEBHOOK_TOKEN" ]; then
  # 使用固定的 webhook token（Jenkins GitLab 插件接受）
  WEBHOOK_TOKEN=""
fi

WEBHOOK_URL="${JENKINS_URL}/project/jenkins-sample"

# 在 GitLab 專案設定 Webhook
WEBHOOK_RESULT=$(curl -s -o /dev/null -w "%{http_code}" \
  -X POST "${GITLAB_URL}/api/v4/projects/root%2F${PROJECT_NAME}/hooks" \
  -H "PRIVATE-TOKEN: ${GITLAB_TOKEN}" \
  -H "Content-Type: application/json" \
  -d "{
    \"url\": \"${WEBHOOK_URL}\",
    \"push_events\": true,
    \"merge_requests_events\": true,
    \"enable_ssl_verification\": false
  }")

if [ "$WEBHOOK_RESULT" = "201" ]; then
  echo "✅ Webhook 設定成功！"
  echo "   GitLab Webhook URL: ${WEBHOOK_URL}"
else
  echo "⚠️  Webhook 設定失敗 (HTTP $WEBHOOK_RESULT)"
  echo "   請手動在 GitLab 專案設定 Webhook："
  echo "   URL: ${WEBHOOK_URL}"
fi
echo ""

# ─── 完成摘要 ─────────────────────────────────────────────────────────────────
echo "════════════════════════════════════════════════════════"
echo "✅ POC 設定完成！"
echo ""
echo "📋 服務 URL："
echo "   GitLab  : ${GITLAB_URL}  (帳號: root / 密碼: ${GITLAB_ROOT_PASSWORD})"
echo "   Jenkins : ${JENKINS_URL}  (帳號: ${JENKINS_USER} / 密碼: ${JENKINS_PASSWORD})"
echo ""
echo "📋 GitLab API Token: ${GITLAB_TOKEN}"
echo "   （請妥善保存，之後更新 Jenkins 憑證時需要）"
echo ""
echo "📋 下一步："
echo "   1. 前往 Jenkins UI 確認 'jenkins-sample' Job 已建立"
echo "   2. 手動觸發一次建置，或推送程式碼至 GitLab 觸發 Webhook"
echo "   3. 若要讓 Jenkins 容器也能 clone GitLab 程式碼，"
echo "      確認 jenkins.yaml 中的 gitlab-credentials 憑證設定正確"
echo "════════════════════════════════════════════════════════"
