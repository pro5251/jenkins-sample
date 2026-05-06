# 安裝 jenkins-expert Skill

## 問題摘要

用戶請求安裝 `jenkins-expert/SKILL.md` 作為 GitHub Copilot CLI 的自訂技能（Custom Skill）。

## 回答重點

- `~/.copilot/skills/` 是 GitHub Copilot CLI 自訂技能的安裝目錄
- 已存在舊版 `jenkins-expert.md`，直接以新版覆蓋更新
- 新版 SKILL.md 包含企業級操作（部署、狀態查詢、Log、回滾）

## 執行的操作

1. 讀取 `jenkins-expert/SKILL.md` 確認內容（321 行）
2. 確認 `~/.copilot/skills/jenkins-expert.md` 已存在（舊版）
3. 複製新版覆蓋：`cp jenkins-expert/SKILL.md ~/.copilot/skills/jenkins-expert.md`

## 安裝結果

| 項目 | 內容 |
|---|---|
| 來源檔案 | `jenkins-expert/SKILL.md` |
| 安裝目標 | `~/.copilot/skills/jenkins-expert.md` |
| 行數 | 320 行 |
| 狀態 | ✅ 成功 |

## Skill 功能說明

- **Jenkins 文件查詢**：自動 `web_fetch` 官方文件（JCasC、Pipeline、GitLab、Plugins）
- **企業級操作**：部署、查詢建置狀態、取得 Log、回滾
- **官方文件地圖**：涵蓋 Docker、JCasC、Pipeline、Plugins、GitLab 整合、Credentials、Job DSL、安全設定
- **回應語言**：繁體中文（台灣），技術術語保留英文
