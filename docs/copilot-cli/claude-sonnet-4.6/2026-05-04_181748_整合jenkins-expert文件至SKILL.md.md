# 整合 jenkins-expert 文件至 SKILL.md

## 問題摘要

將 `docs/copilot-skills/jenkins-expert.md` 整合至 `jenkins-expert/SKILL.md`，並刪除原始來源檔案。

## 回答重點

兩個檔案定位不同，需完整合併：
- `jenkins-expert.md`：知識型，查詢官方文件、回答 Jenkins 相關問題
- `SKILL.md`：操作型，執行 shell scripts 進行部署、查狀態等企業級操作

## 執行的操作

1. 讀取兩個檔案內容，分析各自功能
2. 更新 `jenkins-expert/SKILL.md`：
   - 更新 frontmatter：`name` 改為 `jenkins-expert`，`allowed-tools` 新增 `web_fetch`，`description` 合併兩者
   - 加入官方文件地圖（Docker、JCasC、Pipeline、插件、GitLab、Docker Socket、Credentials、Job DSL、安全設定）
   - 加入常見問題對應表
   - 加入本專案 Jenkins 配置位置說明
   - 加入搜尋插件文件策略
   - 加入重要原則
   - 加入本專案插件清單
   - 保留原有企業級操作內容（部署、查狀態、日誌、回滾）
3. 刪除 `docs/copilot-skills/jenkins-expert.md`

## 產出的檔案

| 檔案 | 操作 |
|---|---|
| `jenkins-expert/SKILL.md` | 更新（整合後的完整版本） |
| `docs/copilot-skills/jenkins-expert.md` | 刪除 |
