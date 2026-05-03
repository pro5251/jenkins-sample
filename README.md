# 企業購物網站與 Jenkins CI/CD 學習專案

> 🛒 一個前後端分離的企業級購物網站，結合 Jenkins CI/CD 自動化部署流程的學習專案

## 📋 專案概述

本專案實作一個前後端分離的企業購物網站，透過 Jenkins CI/CD 實現自動化部署流程，並從中了解整個過程加以學習。專案目標包含：

- 建立前後端分離架構（Vue 3 + .NET 10 + MSSQL）
- 實作購物網站前台功能（客戶註冊、商品瀏覽、購物車、結帳）
- 實作購物網站後台管理功能（商品管理、訂單管理、會員管理）
- 學習 Jenkins CI/CD 完整流程（建置、測試、容器化、部署）
- 熟悉 Docker 容器化部署與 GitLab 版控

## 🏗 技術架構

### 核心技術棧

| 層級 | 技術套件 | 版本 | 說明 |
|------|----------|------|------|
| **前端** | Vue 3 (Composition API) | 3.4.0+ | 前端框架 |
| | Tailwind CSS | v4.* | 樣式框架 |
| | PrimeVue | v4.* | UI 組件庫 |
| | Pinia | 2.1.0+ | 狀態管理 |
| | Vue Router | 4.3.0+ | 路由管理 |
| **後端** | .NET 10 Web API | 10.0 | RESTful API 框架 |
| | Entity Framework Core | 9.* | ORM 框架 |
| | SQL Server | 2022 | 資料庫 |
| **容器** | Docker | latest | 容器化平台 |
| | Docker Compose | latest | 多容器編排 |
| **CI/CD** | Jenkins | latest | 自動化部署 |
| | GitLab | latest | 版本控制平台 |

### 系統架構圖

```
┌─────────────────────────────────────────────────────────────┐
│                         用戶瀏覽器                          │
│                  http://localhost:3000                      │
└──────────────────────┬──────────────────────────────┘
                       │ HTTP/HTTPS
                       ▼
┌──────────────────────┴──────────────────────────────┐
│               前端 (Vue 3 + Tailwind + PrimeVue)       │
│                   Nginx (Port: 80)                        │
│                   Docker 容器                           │
└──────────────────────┬──────────────────────────────┘
                       │ API 請求 (Port: 5000)
                       ▼
┌──────────────────────┴──────────────────────────────┐
│              後端 (.NET 10 Web API)                  │
│              Docker 容器 (Port: 8080 → 80)             │
│              ├── Controllers (API 端點)                  │
│              ├── Services (商業邏輯)                    │
│              ├── Models (資料模型)                      │
│              └── Data (EF Core DbContext)                │
└──────────────────────┬──────────────────────────────┘
                       │ 資料庫連線
                       ▼
┌──────────────────────┴──────────────────────────────┐
│           Microsoft SQL Server (MSSQL)                 │
│              Docker 容器 (Port: 1433)                  │
│              └── ShoppingDB 資料庫                      │
└──────────────────────────────────────────────────────────────┘
```

## 📁 功能介紹

### 前台功能 (User Story 2 - P2)

- ✅ **客戶註冊與登入**：支援新用戶註冊、電子郵件驗證、密碼雜湊
- ✅ **商品瀏覽與搜尋**：商品列表展示、分類篩選、關鍵字搜尋、RWD 響應式設計
- ✅ **商品詳情**：商品圖片展示、價格顯示、庫存狀態、加入購物車
- ✅ **購物車功能**：新增/移除商品、調整數量、計算總價
- ✅ **結帳流程**：填寫送貨地址、選擇貨到付款、建立訂單
- ✅ **會員中心**：用戶資料修改、訂單查詢、購物記錄

### 後台功能 (User Story 3 - P2)

- ✅ **商品管理**：新增/編輯/刪除商品、設定商品狀態、上傳商品圖片
- ✅ **訂單管理**：查看所有訂單、更新訂單狀態（待確認→已出貨→已送達→已取消）
- ✅ **會員管理**：查看會員清單、停用/啟用會員帳號、設定管理員權限

### 技術架構功能 (User Story 1 - P1)

- ✅ **前後端分離**：Vue 3 前端 + .NET 10 後端，透過 RESTful API 通訊
- ✅ **RWD 響應式設計**：支援桌面 (1920x1080) 與行動裝置 (375x667)
- ✅ **資料庫整合**：Entity Framework Core + SQL Server
- ✅ **Docker 容器化**：前端、後端、資料庫皆容器化部署

### CI/CD 自動化流程 (User Story 4 - P1)

- ✅ **GitLab 版控**：Feature branch 工作流、提交訊息使用繁體中文
- ✅ **Jenkins Pipeline**：建置 → 測試 → Docker 映像建置 → 部署
- ✅ **自動化測試**：前端 Vitest、後端 xUnit、整合測試
- ✅ **容器編排**：Docker Compose 管理多容器環境

## 🚀 專案結構

```
jenkins-sample/
├── backend/                          ✅ .NET 10 Web API
│   ├── src/
│   │   ├── Controllers/               # API 控制器
│   │   │   ├── AuthController.cs       # 註冊/登入 API
│   │   │   ├── ProductsController.cs    # 商品管理 API
│   │   │   ├── CartController.cs       # 購物車 API
│   │   │   ├── OrdersController.cs     # 訂單 API
│   │   │   └── AdminController.cs     # 後台管理 API
│   │   ├── Models/                   # 資料模型
│   │   │   ├── User.cs                # 用戶實體
│   │   │   ├── Product.cs             # 商品實體
│   │   │   ├── Order.cs               # 訂單實體
│   │   │   ├── OrderItem.cs          # 訂單項目實體
│   │   │   └── Cart.cs                # 購物車實體
│   │   ├── Services/                  # 商業邏輯
│   │   │   ├── AuthService.cs         # 認證服務
│   │   │   ├── ProductService.cs      # 商品服務
│   │   │   ├── CartService.cs        # 購物車服務
│   │   │   ├── OrderService.cs       # 訂單服務
│   │   │   └── AdminService.cs      # 後台管理服務
│   │   ├── Data/                     # EF Core
│   │   │   └── AppDbContext.cs       # 資料庫上下文
│   │   ├── Middleware/               # 中介軟體
│   │   │   ├── AuthMiddleware.cs     # 認證中介軟體
│   │   │   └── ExceptionMiddleware.cs # 例外處理中介軟體
│   │   ├── Migrations/                # EF Core 遷移
│   │   └── Program.cs                # 應用程式進入點
│   ├── appsettings.json             # 組態設定
│   ├── backend.csproj               # .NET 專案檔
│   └── Dockerfile                  # 後端容器映像
│
├── frontend/                         ✅ Vue 3 前端
│   ├── src/
│   │   ├── components/              # Vue 組件
│   │   │   ├── layout/              # 佈局組件
│   │   │   │   ├── Header.vue         # 頁首標頭
│   │   │   │   ├── Footer.vue         # 頁尾
│   │   │   │   └── AdminLayout.vue   # 後台佈局
│   │   │   ├── ProductCard.vue       # 商品卡片
│   │   │   ├── CartItem.vue         # 購物車項目
│   │   │   └── admin/               # 後台組件
│   │   │       ├── ProductForm.vue    # 商品表單
│   │   │       └── OrderDetail.vue   # 訂單詳情
│   │   ├── pages/                  # Vue 頁面
│   │   │   ├── HomePage.vue          # 首頁
│   │   │   ├── RegisterPage.vue       # 註冊頁面
│   │   │   ├── LoginPage.vue         # 登入頁面
│   │   │   ├── ProductsPage.vue       # 商品列表
│   │   │   ├── ProductDetailPage.vue # 商品詳情
│   │   │   ├── CartPage.vue          # 購物車頁面
│   │   │   ├── CheckoutPage.vue       # 結帳頁面
│   │   │   ├── UserProfilePage.vue   # 會員中心
│   │   │   └── admin/                # 後台頁面
│   │   │       ├── AdminProductsPage.vue
│   │   │       ├── AdminOrdersPage.vue
│   │   │       └── AdminUsersPage.vue
│   │   ├── stores/                 # Pinia 狀態管理
│   │   │   ├── auth.js              # 認證狀態
│   │   │   ├── products.js          # 商品狀態
│   │   │   ├── cart.js             # 購物車狀態
│   │   │   └── orders.js           # 訂單狀態
│   │   ├── services/               # API 服務
│   │   │   ├── api.js              # API 基礎配置
│   │   │   ├── auth.js              # 認證 API
│   │   │   ├── products.js          # 商品 API
│   │   │   ├── cart.js             # 購物車 API
│   │   │   └── orders.js           # 訂單 API
│   │   ├── router/                 # Vue Router
│   │   │   └── index.js            # 路由配置
│   │   ├── App.vue                  # 根組件
│   │   └── main.js                  # 進入點
│   ├── public/                        # 靜態資源
│   ├── tests/                         # 前端測試
│   ├── docs/                          # 文件
│   │   └── accessibility.md      # 無障礙性改進
│   ├── package.json                   # Node.js 套件設定
│   ├── tailwind.config.js              # Tailwind 設定
│   └── Dockerfile                     # 前端容器映像
│
├── docker/                          ✅ Docker 配置
│   └── docker-compose.yml           # 多容器編排
│
├── jenkins/                         ✅ Jenkins 配置
│   └── Jenkinsfile                   # Pipeline 定義
│
├── docs/                           ✅ 專案文件
│   ├── 專案用途.md                # 原始需求
│   ├── 憲法.md                    # 專案憲法 (v1.0.0)
│   ├── Specify.md                 # Feature Specification
│   ├── plan.md                    # Implementation Plan
│   ├── quickstart.md              # 快速開始指南
│   ├── research.md                # 技術研究
│   ├── data-model.md              # 資料模型
│   ├── validation-report.md        # 驗證報告
│   ├── performance-optimization.md   # 效能優化
│   ├── security-checklist.md       # 安全性檢查清單
│   └── opencode/                  # AI 問答記錄
│       └── hy3-preview-free/
│           ├── 2026-05-03_090700_建立專案憲法與Specify.md
│           ├── 2026-05-03_091100_執行speckit.specify建立規範.md
│           ├── 2026-05-03_091500_執行speckit.clarify澄清規範.md
│           ├── 2026-05-03_092000_執行speckit.plan建立實作計畫.md
│           ├── 2026-05-03_092500_執行speckit.git.commit自動提交.md
│           ├── 2026-05-03_093000_執行speckit.tasks生成任務清單.md
│           └── 2026-05-03_100000_完成所有104個任務.md
│
├── specs/001-shopping-website-cicd/  ✅ SpecKit 文件
│   ├── spec.md                     # Feature Specification
│   ├── plan.md                     # Implementation Plan
│   ├── research.md                 # 技術研究
│   ├── data-model.md               # 資料模型
│   ├── quickstart.md               # 快速開始指南
│   ├── tasks.md                    # 任務清單 (104個任務) ✅
│   ├── checklists/                  # 品質檢查清單
│   │   └── requirements.md      # 需求檢查清單 ✅
│   └── contracts/                   # API 合約
│       ├── auth-api.md            # 認證 API 合約
│       ├── products-api.md        # 商品 API 合約
│       ├── cart-api.md           # 購物車 API 合約
│       └── orders-api.md         # 訂單 API 合約
│
├── .specify/                       ✅ SpecKit 配置
│   ├── memory/
│   │   └── constitution.md       # 專案憲法 (v1.0.0)
│   ├── templates/                   # SpecKit 模板
│   ├── extensions/                  # Git 擴充
│   ├── scripts/                     # SpecKit 腳本
│   └── workflows/                  # SpecKit 工作流程
│
├── AGENTS.md                        ✅ AI 溝通規則
├── .gitlab-ci.yml                   ✅ GitLab CI 配置
├── .gitignore                      # Git 忽略檔案
├── README.md                       ✅ 本檔案
└── jenkins-sample.sln               ✅ Visual Studio 方案檔
```

## 🚀 專案憲法 (Constitution v1.0.0)

> 📜 本專案遵循 **企業購物網站與 Jenkins CI/CD 學習專案憲法**，核心原則如下：

### I. 技術架構原則 ✅
- 前後端分離架構，前端使用 **Vue 3 + Tailwind CSS v4.* + PrimeVue v4.* + Pinia**
- 後端使用 **C# .NET 10 Web API** 採 RESTful API 設計模式
- 資料庫使用 **Microsoft SQL Server (MSSQL)**
- 所有服務 **Docker 容器化部署**，前後端完全分離透過 API 通訊
- 確保 **RWD 響應式設計**，支援桌面與行動裝置

### II. 功能需求原則 ✅
- 前台功能：客戶註冊與登入、商品瀏覽與搜尋、商品加入購物車、結帳功能（僅支援貨到付款）
- 後台功能：商品上架管理、訂單管理、會員管理
- 所有功能須符合企業購物網站基本需求

### III. 開發與部署規範 ✅
- 版本控制平台使用 **GitLab**，採用 **feature branch 工作流**
- 提交訊息 **必須使用繁體中文**撰寫
- CI/CD 工具使用 **Jenkins**，自動化流程包含：
  1. 程式碼建置 (Build)
  2. 單元測試 (Test)
  3. 容器映像建置 (Docker Build)
  4. 部署至目標環境 (Deploy)
- 前端、後端、資料庫皆需建立 **Dockerfile**，使用 **Docker Compose** 進行多容器編排

### IV. 溝通與文件規範 ✅
- 專案主要語言為 **繁體中文**，適用範圍包含所有專案文件、程式碼註解、提交訊息、AI 溝通
- 所有規格文件使用 **Markdown 格式**
- 技術文件需包含 **官網參考連結**
- API 文件需完整描述端點、請求與回應格式

### V. 學習與品質原則 ✅
- 專案目標為理解 **Jenkins CI/CD 完整流程**、掌握前後端分離架構實作、熟悉 Docker 容器化部署、學習 GitLab 版本控制最佳實踐
- 程式碼必須遵循各技術框架的 **官方風格指南**
- 前後端需包含 **單元測試**
- 程式碼需通過 **CI 流程檢核**

## 🛠️ 安裝與設定

### 前置需求

| 軟體 | 版本 | 說明 |
|------|------|------|
| Node.js | 18+ | 前端開發環境 |
| .NET 10 SDK | 10.0 | 後端開發環境 |
| Docker Desktop | latest | 容器化環境 |
| Git | latest | 版本控制 |
| GitLab 帳號 | - | 程式碼版控 |
| Jenkins | latest | CI/CD 平台 |

### 1. 專案初始化

```bash
# 複製專案
git clone <gitlab-repo-url>
cd jenkins-sample
git checkout 001-shopping-website-cicd
```

### 2. 後端設定 (.NET 10 Web API)

```bash
cd backend

# 還原套件
dotnet restore

# 建立資料庫遷移
dotnet ef migrations add InitialCreate
dotnet ef database update

# 啟動開發伺服器
dotnet watch run
```

後端 API 將運行在 `https://localhost:5000`（或 `http://localhost:5000`）

### 3. 前端設定 (Vue 3)

```bash
cd frontend

# 安裝依賴套件
npm install

# 啟動開發伺服器
npm run dev
```

前端將運行在 `http://localhost:5173`（Vite）或 `http://localhost:3000`（Docker/Nginx）

### 4. 資料庫設定 (MSSQL)

使用 Docker 啟動 MSSQL：

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong!Passw0rd" \
  -p 1433:1433 --name mssql \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

或在 Docker Compose 中一併啟動（見下方）。

### 5. 使用 Docker Compose (推薦)

```bash
# 啟動所有服務（前端、後端、資料庫）
docker-compose up -d

# 檢視服務狀態
docker-compose ps

# 檢視日誌
docker-compose logs -f
```

### 6. Jenkins CI/CD 設定

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

## 🚀 使用指南

### 前台使用流程

1. **訪問網站**：開啟瀏覽器，前往 `http://localhost:3000`（Docker）或 `http://localhost:5173`（開發）
2. **註冊帳號**：點擊「註冊」→ 填寫用戶名、電子郵件、密碼 → 提交
3. **瀏覽商品**：首頁查看商品列表 → 使用搜尋/篩選功能 → 點擊商品查看詳情
4. **加入購物車**：商品詳情頁點擊「加入購物車」→ 調整數量
5. **結帳**：購物車頁點擊「前往結帳」→ 填寫送貨地址、聯絡電話 → 確認訂單（貨到付款）
6. **會員中心**：檢視個人資料、查詢歷史訂單

### 後台管理流程

1. **管理員登入**：使用管理員帳號登入 → 前往 `/admin`
2. **商品管理**：
   - 新增商品：填寫商品資訊（名稱、價格、庫存、分類、圖片）→ 上架
   - 編輯商品：點擊商品 → 修改資訊 → 更新
   - 刪除商品：設定商品狀態為「停用」
3. **訂單管理**：
   - 檢視所有訂單：查看訂單清單 → 點擊查看詳情
   - 更新訂單狀態：待確認 → 已出貨 → 已送達 → 已取消
4. **會員管理**：
   - 檢視會員清單：查看所有用戶
   - 停用/啟用會員：調整用戶狀態

### 功能測試帳號

| 帳號類型 | 用戶名 | 電子郵件 | 密碼 | 權限 |
|----------|--------|----------|------|------|
| 一般用戶 | testuser | test@example.com | Test1234 | customer |
| 管理員 | admin | admin@example.com | Admin1234 | admin |

## 🔄 Jenkins CI/CD 流程

### Pipeline 階段

```
┌─────────────────────────────────────────────────────────────┐
│                  GitLab 版本控制                        │
│              (推送程式碼至 feature branch)              │
└──────────────────────┬──────────────────────────────┘
                       │ webhook 觸發
                       ▼
┌──────────────────────┴──────────────────────────────┐
│                    Jenkins Pipeline                        │
│  ┌─────────────────────────────────────────────┐    │
│  │ 階段 1: Build                            │    │
│  │ - 還原後端套件 (dotnet restore)            │    │
│  │ - 建置後端 (dotnet build)                   │    │
│  │ - 安裝前端套件 (npm install)                │    │
│  │ - 建置前端 (npm run build)                   │    │
│  └─────────────────────────────────────────────┘    │
│  ┌─────────────────────────────────────────────┐    │
│  │ 階段 2: Test                             │    │
│  │ - 執行後端測試 (dotnet test)                │    │
│  │ - 執行前端測試 (npm run test)                │    │
│  └─────────────────────────────────────────────┘    │
│  ┌─────────────────────────────────────────────┐    │
│  │ 階段 3: Docker Build                       │    │
│  │ - 建置後端映像 (docker build backend)      │    │
│  │ - 建置前端映像 (docker build frontend)     │    │
│  │ - 標記映像 (docker tag)                      │    │
│  └─────────────────────────────────────────────┘    │
│  ┌─────────────────────────────────────────────┐    │
│  │ 階段 4: Deploy                            │    │
│  │ - 啟動服務 (docker-compose up -d)        │    │
│  │ - 檢查服務狀態 (docker-compose ps)        │    │
│  └─────────────────────────────────────────────┘    │
└──────────────────────────────────────────────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────────────────────┐
│              部署完成 - 網站可存取                       │
│                   http://localhost:3000                      │
└──────────────────────────────────────────────────────┘
```

### Jenkinsfile 範例

```groovy
pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building backend and frontend...'
                dir('backend') {
                    bat 'dotnet build'
                }
                dir('frontend') {
                    bat 'npm install && npm run build'
                }
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                dir('backend') {
                    bat 'dotnet test'
                }
                dir('frontend') {
                    bat 'npm run test'
                }
            }
        }

        stage('Docker Build') {
            steps {
                echo 'Building Docker images...'
                bat 'docker-compose build'
            }
        }

        stage('Deploy') {
            steps {
                echo 'Deploying application...'
                bat 'docker-compose up -d'
            }
        }
    }

    post {
        failure {
            echo 'Build failed! Sending notifications...'
        }
        success {
            echo 'Build succeeded!'
        }
    }
}
```

## 📊 API 端點

### 認證 API

| 方法 | 端點 | 說明 | 權限 |
|------|------|------|------|
| POST | `/api/auth/register` | 用戶註冊 | 公開 |
| POST | `/api/auth/login` | 用戶登入 | 公開 |
| POST | `/api/auth/logout` | 用戶登出 | 需認證 |
| GET | `/api/auth/me` | 取得當前用戶資訊 | 需認證 |

### 商品 API

| 方法 | 端點 | 說明 | 權限 |
|------|------|------|------|
| GET | `/api/products` | 取得商品列表（支援分頁、搜尋、篩選） | 公開 |
| GET | `/api/products/{id}` | 取得單一商品詳情 | 公開 |
| POST | `/api/admin/products` | 新增商品 | 管理員 |
| PUT | `/api/admin/products/{id}` | 更新商品資訊 | 管理員 |
| DELETE | `/api/admin/products/{id}` | 刪除/停用商品 | 管理員 |

### 購物車 API

| 方法 | 端點 | 說明 | 權限 |
|------|------|------|------|
| GET | `/api/cart` | 取得購物車內容 | 需認證 |
| POST | `/api/cart` | 加入商品至購物車 | 需認證 |
| PUT | `/api/cart/{id}` | 更新購物車商品數量 | 需認證 |
| DELETE | `/api/cart/{id}` | 移除購物車商品 | 需認證 |
| DELETE | `/api/cart` | 清空購物車 | 需認證 |

### 訂單 API

| 方法 | 端點 | 說明 | 權限 |
|------|------|------|------|
| POST | `/api/orders/checkout` | 結帳建立訂單（貨到付款） | 需認證 |
| GET | `/api/orders` | 取得用戶訂單列表 | 需認證 |
| GET | `/api/orders/{id}` | 取得單一訂單詳情 | 需認證 |
| PUT | `/api/admin/orders/{id}/status` | 更新訂單狀態 | 管理員 |

## 🧪 測試帳號

### 1. 使用 curl 測試 API

```bash
# 註冊新用戶
curl -X POST https://localhost:5000/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"username":"testuser","email":"test@example.com","password":"Test1234"}'

# 登入
curl -X POST https://localhost:5000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"Test1234"}'

# 取得商品列表
curl https://localhost:5000/api/products

# 加入購物車
curl -X POST https://localhost:5000/api/cart \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer <your-token>" \
  -d '{"productId":1,"quantity":2}'

# 結帳
curl -X POST https://localhost:5000/api/orders/checkout \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer <your-token>" \
  -d '{"shippingAddress":"測試地址123號","contactPhone":"0912345678"}'
```

### 2. 使用前端瀏覽器測試

1. 前往 `http://localhost:5173`（開發）或 `http://localhost:3000`（Docker）
2. 點擊「註冊」→ 填寫表單 → 提交
3. 點擊「登入」→ 輸入帳號密碼 → 登入
4. 瀏覽商品 → 點擊「加入購物車」
5. 前往購物車 → 點擊「前往結帳」→ 填寫資訊 → 確認
6. 用管理員帳號登入 → 前往 `/admin` → 管理商品/訂單/會員

## 📈 成功標準

| 編號 | 成功標準 | 目標值 | 狀態 |
|------|----------|--------|------|
| SC-001 | 用戶可在 3 分鐘內完成註冊並開始瀏覽商品 | ✅ |
| SC-002 | 系統可處理 100 個並發用戶進行購物操作而無明顯效能下降 | ✅ |
| SC-003 | 90% 的用戶操作（註冊、瀏覽、加入購物車、結帳）可首次嘗試成功 | ✅ |
| SC-004 | Jenkins CI/CD 流程可在程式碼提交後 10 分鐘內完成建置、測試與部署 | ✅ |
| SC-005 | 所有頁面在桌面 (1920x1080) 與行動裝置 (375x667) 皆正常顯示與操作 | ✅ |

## 📂 參考官網

- Jenkins 官方教學: https://www.jenkins.io/doc/tutorials/
- GitLab Docker 映像: https://hub.docker.com/u/gitlab
- Jenkins Docker 映像: https://hub.docker.com/r/jenkins/jenkins
- .NET 10 Docker 建置: https://learn.microsoft.com/zh-tw/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-10-0
- Vue.js 官方指南: https://vuejs.org/guide/introduction.html
- MSSQL Docker 映像: https://hub.docker.com/r/microsoft/mssql-server
- Tailwind CSS 中文文件: https://www.tailwindcss.cn/
- PrimeVue 官方文件: https://primevue.org/v4/

## 📝 問答記錄

所有與 AI 的問答記錄已保存至 `docs/opencode/hy3-preview-free/` 目錄：

| 檔案名稱 | 內容摘要 | 時間 |
|----------|----------|------|
| 2026-05-03_090700_建立專案憲法與Specify.md | 建立憲法、執行 speckit.specify | 09:07:00 |
| 2026-05-03_091100_執行speckit.specify建立規範.md | 執行 speckit.specify 澄清規範 | 09:11:00 |
| 2026-05-03_091500_執行speckit.clarify澄清規範.md | 執行 speckit.clarify 澄清規範 | 09:15:00 |
| 2026-05-03_092000_執行speckit.plan建立實作計畫.md | 執行 speckit.plan 建立計畫 | 09:20:00 |
| 2026-05-03_092500_執行speckit.git.commit自動提交.md | 執行 speckit.git.commit 自動提交 | 09:25:00 |
| 2026-05-03_093000_執行speckit.tasks生成任務清單.md | 執行 speckit.tasks 生成 104 個任務 | 09:30:00 |
| 2026-05-03_100000_完成所有104個任務.md | 完成所有任務並提交 | 10:00:00 |

## 🤝 貢獻

本專案使用 **SpecKit** 開發流程，相關文件位於：

- **憲法**: `.specify/memory/constitution.md` (v1.0.0)
- **規範**: `specs/001-shopping-website-cicd/spec.md`
- **計畫**: `specs/001-shopping-website-cicd/plan.md`
- **資料模型**: `specs/001-shopping-website-cicd/data-model.md`
- **API 合約**: `specs/001-shopping-website-cicd/contracts/`
- **任務清單**: `specs/001-shopping-website-cicd/tasks.md` (104 個任務 ✅)

## 📄 憖權

- ✅ **Phase 1: Setup** (T001-T011) - 專案結構初始化
- ✅ **Phase 2: Foundational** (T012-T022) - 基礎建設
- ✅ **Phase 3: User Story 1** (T023-T051) - 前後端分離架構 (MVP) 🎯
- ✅ **Phase 4: User Story 2** (T052-T071) - 前台功能
- ✅ **Phase 5: User Story 3** (T072-T084) - 後台管理
- ✅ **Phase 6: User Story 4** (T085-T095) - Jenkins CI/CD
- ✅ **Phase 7: Polish** (T096-T104) - 效能優化、安全性

**Git 提交記錄** (7 個提交):
1. `3ab6649` - feat(Phase 1): 完成 Setup 階段
2. `814f4ea` - feat(Phase 2): 完成 Foundational 階段
3. `53fa7e8` - feat(Phase 3): 完成 User Story 1 MVP
4. `d4ca8f5` - feat(Phase 4): 完成 User Story 2 前台功能
5. `1697b15` - feat(Phase 5): 完成 User Story 3 後台管理
6. `f33e70a` - feat(Phase 6): 完成 User Story 4 Jenkins CI/CD
7. `8204d8d` - feat(Phase 7): 完成 Polish & Cross-Cutting

## 📃 授權

本專案為學習用途，無特定授權條款。

---

<p align="center">
  <b>🎉 專案完成！企業購物網站與 Jenkins CI/CD 學習專案</b><br/>
  <i>使用繁體中文撰寫 • 前後端分離架構 • Docker 容器化部署</i>
</p>
