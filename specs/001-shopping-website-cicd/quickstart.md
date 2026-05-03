# Quickstart Guide: 企業購物網站與 Jenkins CI/CD 學習專案

**Created**: 2026-05-03
**Feature**: [spec.md](../spec.md)

## Prerequisites

- Node.js 18+ (前端開發)
- .NET 10 SDK (後端開發)
- Docker Desktop (容器化環境)
- Git (版本控制)
- GitLab 帳號 (程式碼版控)
- Jenkins 伺服器或 Docker 容器 (CI/CD)

## Local Development Setup

### 1. Clone Repository

```bash
git clone <gitlab-repo-url>
cd jenkins-sample
git checkout 001-shopping-website-cicd
```

### 2. Backend Setup (.NET 10 Web API)

```bash
cd backend

# 還原套件
dotnet restore

# 更新資料庫遷移
dotnet ef database update

# 啟動開發伺服器
dotnet watch run
```

後端 API 將運行在 `https://localhost:5001` (或 `http://localhost:5000`)

### 3. Frontend Setup (Vue 3)

```bash
cd frontend

# 安裝依賴套件
npm install

# 啟動開發伺服器
npm run dev
```

前端將運行在 `http://localhost:5173`

### 4. Database Setup (MSSQL)

使用 Docker 啟動 MSSQL：

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword123!" \
  -p 1433:1433 --name mssql \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

或在 Docker Compose 中一併啟動（見下方）。

### 5. Using Docker Compose (Recommended)

```bash
# 啟動所有服務（前端、後端、資料庫）
docker-compose up -d

# 查看服務狀態
docker-compose ps

# 查看日誌
docker-compose logs -f
```

## Project Structure

```
jenkins-sample/
├── backend/               # .NET 10 Web API
│   ├── Controllers/      # API 控制器
│   ├── Models/           # 資料模型
│   ├── Services/         # 商業邏輯
│   ├── Data/             # DbContext
│   └── Program.cs       # 進入點
├── frontend/             # Vue 3 前端
│   ├── src/
│   │   ├── components/  # Vue 組件
│   │   ├── pages/       # 頁面
│   │   ├── stores/      # Pinia 狀態
│   │   └── services/    # API 服務
│   └── package.json
├── docker/              # Docker 配置
│   └── docker-compose.yml
├── jenkins/             # Jenkins 配置
│   └── Jenkinsfile
└── specs/              # 規範文件
    └── 001-shopping-website-cicd/
```

## Key Commands

### Backend

```bash
# 建置專案
dotnet build

# 執行單元測試
dotnet test

# 新增資料庫遷移
dotnet ef migrations add <MigrationName>

# 更新資料庫
dotnet ef database update
```

### Frontend

```bash
# 建置專案
npm run build

# 執行單元測試
npm run test

# 程式碼檢查
npm run lint
```

## API Testing

使用 Postman 或 curl 測試 API：

```bash
# 註冊新用戶
curl -X POST https://localhost:5001/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"username":"testuser","email":"test@example.com","password":"Test1234"}'

# 登入
curl -X POST https://localhost:5001/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"Test1234"}'
```

## Jenkins CI/CD Quick Start

1. 確保 GitLab 專案已設定 webhook 觸發 Jenkins
2. 推送程式碼至 feature branch：
   ```bash
   git add .
   git commit -m "feat: 實作用戶註冊功能"
   git push origin 001-shopping-website-cicd
   ```
3. Jenkins 將自動觸發 Pipeline：
   - Build: 建置前端與後端
   - Test: 執行單元測試
   - Docker Build: 建置 Docker 映像
   - Deploy: 部署至目標環境

## Common Issues

### MSSQL 連線失敗
- 檢查 SA 密碼是否符合複雜度要求
- 確認 Docker 容器正在運行：`docker ps`
- 檢查連線字串中的密碼是否正確

### 前端無法連線後端 API
- 確認後端 API 正在運行
- 檢查 CORS 設定是否允許前端來源
- 確認 API 基礎 URL 設定正確

### Jenkins Pipeline 失敗
- 檢查 Jenkins 日誌：`docker logs jenkins`
- 確認 Jenkinsfile 語法正確
- 驗證 GitLab webhook 設定

## Next Steps

1. 閱讀 [spec.md](../spec.md) 了解功能需求
2. 閱讀 [data-model.md](data-model.md) 了解資料模型
3. 閱讀 [research.md](research.md) 了解技術選型
4. 開始實作 [User Story 1](../spec.md#user-story1---建立前後端分離購物網站基礎架構-priority-p1)
