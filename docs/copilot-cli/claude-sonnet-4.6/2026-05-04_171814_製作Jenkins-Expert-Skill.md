# 製作 Jenkins Expert Skill

## 問題摘要
使用者希望製作一份 Copilot CLI Skill，讓 AI 在處理 Jenkins 相關問題時，能快速找到官方文件中正確的資訊來源。

## 回答重點

### Skill 系統說明
- **Skill 位置**：`~/.copilot/skills/*.md`（每個 `.md` 檔案 = 一個 Skill）
- **觸發方式**：在對話中提及 Skill 名稱或相關關鍵字，Copilot 會自動載入該 Skill 作為系統指令
- **Skill 內容**：包含工作流程、官方文件 URL 地圖、常見問題對照表等

### jenkins-expert Skill 設計
Skill 核心架構分為 7 大類官方文件地圖：

| 類別 | 覆蓋範圍 |
|---|---|
| Jenkins Docker 映像 | 官方 README、Docker Hub、Docker 安裝教學 |
| JCasC（Configuration as Code）| 官方文件、Schema、Secrets、範例大全 |
| Pipeline（Jenkinsfile）| 語法參考、Steps、parallel、shared-libraries |
| 插件（Plugins）| 搜尋首頁 + 本專案使用的 13 個插件文件 |
| GitLab + Jenkins 整合 | GitLab Plugin README、JCasC 範例、Webhook 設定 |
| Credentials（憑證管理）| 使用文件、JCasC 設定、Binding Steps |
| Job DSL | API 完整參考、pipelineJob 語法 |

還包含：
- 常見問題 → 對應文件快速對照表（14 個）
- 本專案 Jenkins 配置位置說明
- 搜尋插件文件的策略

## 執行的操作
1. 研究 `~/.copilot/skills/` 目錄結構與現有 `docker-troubleshoot.md` 格式
2. 建立 `docs/copilot-skills/jenkins-expert.md`（Skill 原始碼）
3. 建立 `docs/copilot-skills/install-jenkins-expert.sh`（安裝腳本）
4. 執行安裝腳本，將 Skill 安裝至 `~/.copilot/skills/jenkins-expert.md`

## 產出的檔案
- `docs/copilot-skills/jenkins-expert.md` — Skill 原始碼
- `docs/copilot-skills/install-jenkins-expert.sh` — 安裝腳本
- `~/.copilot/skills/jenkins-expert.md` — 已安裝的 Skill（系統層）

## 使用方式
```
# 安裝（或更新）Skill
./docs/copilot-skills/install-jenkins-expert.sh

# 在 Copilot CLI 對話中觸發
使用 jenkins-expert 幫我設定 JCasC 憑證
Jenkins GitLab Webhook 怎麼設定？
```

## 未來可擴充方向
- 加入 Jenkins Agent / Node 設定文件
- 加入 Blue Ocean 文件
- 加入 Jenkins Shared Library 範例連結
- 加入本專案實際 jenkins.yaml 的 inline 說明
