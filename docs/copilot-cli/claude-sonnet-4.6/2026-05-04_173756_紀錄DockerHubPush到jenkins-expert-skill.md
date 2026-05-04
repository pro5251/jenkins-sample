# 將 Docker Hub Push 文件紀錄到 jenkins-expert skill

## 問題摘要

使用者要求將搜尋到的 Docker Hub Push 官方文件紀錄到 `jenkins-expert` skill 中。

---

## 執行的操作

修改檔案：`/mnt/d/.github/skills/jenkins-expert/SKILL.md`

### 新增內容

1. **新增 `🚀 Docker Hub Push` 章節**（在 `🐳 Jenkins + Docker Socket` 之後）：
   - 3 個官方文件 URL 對照表
   - `web_fetch` 快速抓取指令
   - 兩種 Push 寫法範例（DSL vs Shell）
   - `docker-compose.yml` 搭配說明

2. **更新「常見問題 → 對應文件」表格**：
   - 新增「如何推送映像到 Docker Hub？」
   - 新增「docker compose push 如何搭配 credentials？」

---

## 新增的官方文件

| 主題 | URL |
|---|---|
| Jenkins Pipeline + Docker Build & Push | https://www.jenkins.io/doc/book/pipeline/docker/ |
| Docker Workflow Plugin DSL 文件 | https://github.com/jenkinsci/docker-workflow-plugin/blob/master/docs/docker-workflow.md |
| Docker CLI push 指令參考 | https://docs.docker.com/reference/cli/docker/image/push/ |
| Docker CLI login 指令參考 | https://docs.docker.com/reference/cli/docker/login/ |

---

## 使用模型
Claude Sonnet 4.6 (claude-sonnet-4.6)
