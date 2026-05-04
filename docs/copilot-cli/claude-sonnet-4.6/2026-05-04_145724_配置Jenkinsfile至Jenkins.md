# 配置 Jenkinsfile 至 Jenkins

## 問題摘要

將 `jenkins/Jenkinsfile` 配置到 Jenkins Pipeline Job 中。

## 架構說明

- Jenkins 由 `docker/ci-cd-docker-compose.yml` 啟動，port 8080
- Jenkins 容器已預裝：Docker CLI、.NET 10 SDK、Node.js 20
- Jenkinsfile 路徑：`jenkins/Jenkinsfile`
- Git Remote：`https://github.com/pro5251/jenkins-sample.git`

## 修正內容

### Jenkinsfile 修正
- 將 `npm run test` 改為 `npm run test -- --run`，防止 vitest 在 CI 進入 watch 模式卡住

## 配置步驟

1. 啟動 Jenkins：`docker compose -f ci-cd-docker-compose.yml up -d jenkins`
2. 取得初始密碼：`docker exec jenkins cat /var/jenkins_home/secrets/initialAdminPassword`
3. 開啟 http://localhost:8080 完成初始設定
4. New Item → Pipeline，設定 SCM 為 Git
5. Script Path 設為 `jenkins/Jenkinsfile`

## 產出檔案

- `jenkins/Jenkinsfile`（修改：vitest --run 旗標）
