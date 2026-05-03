---
name: jenkins-enterprise
description: 企業級 Jenkins 操作（部署、查詢狀態、日誌、回滾），透過 shell script 執行。
allowed-tools: ["shell"]
user-invocable: true
---

# Jenkins Enterprise Skill

此 Skill 將 Jenkins 操作封裝為 shell scripts，提供安全且可控的 CI/CD 操作。

---

## 🔧 環境變數

```bash
export JENKINS_URL="http://your-jenkins-url"
export JENKINS_USER="your-user"
export JENKINS_TOKEN="your-api-token"
```

---

## 🚀 情境對應

### 部署服務
當使用者說：
- 部署 API 到 prod
- deploy service

執行：

```bash
JOB_NAME=deploy-api ENV=prod VERSION=v1 ./scripts/deploy.sh
```

---

### 查詢建置狀態
當使用者說：
- 查 build 狀態

```bash
JOB_NAME=deploy-api BUILD_NUMBER=123 ./scripts/status.sh
```

---

### 取得 Log
當使用者說：
- 查看 log

```bash
JOB_NAME=deploy-api BUILD_NUMBER=123 ./scripts/log.sh
```

---

### 最近成功建置
```bash
JOB_NAME=deploy-api ./scripts/last_success.sh
```

---

### 回滾
```bash
JOB_NAME=deploy-api BUILD_NUMBER=120 ./scripts/rollback.sh
```

---

## ⚠️ 安全規範

- production 必須 APPROVED=true
- 禁止未授權部署
- 不可輸出 token
