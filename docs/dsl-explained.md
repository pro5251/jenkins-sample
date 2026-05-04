# DSL（Domain Specific Language）領域專用語言

## 什麼是 DSL？

DSL（Domain Specific Language，領域專用語言）是為**特定用途**設計的語言，語法貼近該領域的概念與術語，讓使用者用最少的程式碼表達最清楚的意圖。

相對於 Python、Java、C# 這類**通用程式語言（General Purpose Language, GPL）**，DSL 不追求完整的程式能力，而是在特定領域內提供極佳的**可讀性與表達力**。

---

## 日常常見的 DSL

| DSL | 領域 | 範例 |
|-----|------|------|
| **SQL** | 資料庫查詢 | `SELECT * FROM users WHERE age > 18` |
| **CSS** | 網頁樣式 | `button { color: blue; font-size: 16px; }` |
| **HTML** | 網頁結構 | `<h1>Hello World</h1>` |
| **Dockerfile** | 容器建置 | `FROM node:20 \| RUN npm install` |
| **Jenkinsfile** | CI/CD 流程定義 | `stage('Build') { sh 'npm run build' }` |
| **Job DSL** | Jenkins Job 設定 | `pipelineJob('my-job') { ... }` |
| **Terraform HCL** | 雲端基礎設施 | `resource "aws_s3_bucket" "my_bucket" { }` |
| **GraphQL** | API 查詢 | `query { user { name email } }` |
| **Regular Expression** | 文字比對 | `^\d{4}-\d{2}-\d{2}$` |

---

## DSL vs 通用語言的差異

以「建立 Jenkins Pipeline Job」為例：

### ✅ 使用 Job DSL（領域專用）

```groovy
pipelineJob('jenkins-sample') {
  description('Shopping Website CI/CD Pipeline')
  definition {
    cpsScm {
      scm {
        git {
          remote { url('https://github.com/pro5251/jenkins-sample.git') }
          branch('*/main')
        }
      }
      scriptPath('jenkins/Jenkinsfile')
    }
  }
  triggers {
    scm('H/5 * * * *')
  }
}
```

語意清楚，非工程師也能大致讀懂在做什麼。

### ❌ 如果用通用語言做同一件事（概念示意）

```python
import requests, json

# 需要自行處理 Jenkins REST API、認證、CSRF token、XML 格式...
token = get_csrf_token("http://localhost:8080", "admin", "admin")
headers = {"Jenkins-Crumb": token, "Content-Type": "application/xml"}
xml_config = build_job_xml_config(
    repo_url="https://github.com/pro5251/jenkins-sample.git",
    branch="main",
    script_path="jenkins/Jenkinsfile",
    cron="H/5 * * * *"
)
requests.post("http://localhost:8080/createItem?name=jenkins-sample",
              data=xml_config, headers=headers, auth=("admin", "admin"))
```

複雜許多，且容易出錯。

---

## DSL 的核心優點

| 優點 | 說明 |
|------|------|
| **可讀性高** | 語法接近自然語言或領域術語 |
| **減少樣板程式碼** | 隱藏底層複雜的 API 呼叫 |
| **降低出錯率** | 語法限制在特定領域，不易寫出無關邏輯 |
| **易於維護** | 非開發人員（如 DevOps、DBA）也能理解與修改 |

---

## 本專案中的 DSL 應用

| 檔案 | DSL 類型 | 用途 |
|------|---------|------|
| `jenkins/Jenkinsfile` | Jenkins Pipeline DSL（Groovy） | 定義 CI/CD 流程的各個 Stage |
| `docker/jenkins/jenkins.yaml` | JCasC YAML + Job DSL | 自動初始化 Jenkins 系統設定與建立 Job |
| `docker/docker-compose.yml` | Docker Compose DSL（YAML） | 定義多容器服務架構 |
