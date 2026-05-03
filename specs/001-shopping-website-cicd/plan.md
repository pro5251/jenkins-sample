# Implementation Plan: 企業購物網站與 Jenkins CI/CD 學習專案

**Branch**: `001-shopping-website-cicd` | **Date**: 2026-05-03 | **Spec**: [spec.md](../spec.md)
**Input**: Feature specification from `/specs/001-shopping-website-cicd/spec.md`

**Note**: This template is filled in by the `/speckit.plan` command. See `.specify/templates/plan-template.md` for the execution workflow.

## Summary

本專案實作一個前後端分離的企業購物網站，前端採用 Vue 3 + Tailwind CSS v4.* + PrimeVue v4.* + Pinia，實作 RWD 響應式設計；後端採用 C# .NET 10 Web API 建立 RESTful API；資料庫使用 Microsoft SQL Server (MSSQL)。透過 GitLab 進行程式碼版控，使用 Jenkins 建立 CI/CD 自動化流程，實現建置、測試、Docker 容器化與部署。專案目標為學習現代化 DevOps 實踐並建立可用購物網站。

## Technical Context

**Language/Version**: 
- 前端: Vue 3 (Composition API), Tailwind CSS v4.*, PrimeVue v4.*, Pinia
- 後端: C# .NET 10
- 資料庫: Microsoft SQL Server (MSSQL)
- 容器化: Docker, Docker Compose

**Primary Dependencies**: 
- 前端: vue@3, tailwindcss@4.*, primevue@4.*, pinia, vue-router
- 後端: ASP.NET Core 10 Web API, Entity Framework Core, SQL Server driver
- CI/CD: Jenkins, GitLab

**Storage**: Microsoft SQL Server (MSSQL) - 使用 Entity Framework Core 進行 ORM 操作

**Testing**: 
- 前端: Vitest (單元測試), Vue Test Utils
- 後端: xUnit, ASP.NET Core TestServer
- 整合測試: 使用 Docker Compose 進行完整環境測試

**Target Platform**: Web application (跨平台，支援桌面與行動裝置 RWD)

**Project Type**: Web application (前後端分離架構)

**Performance Goals**: 
- 頁面載入時間 < 2 秒
- API 回應時間 p95 < 200ms
- 支援 100 個並發用戶

**Constraints**: 
- 僅支援貨到付款，不實作第三方支付
- 所有程式碼、文件、提交訊息必須使用繁體中文
- 所有服務必須 Docker 容器化部署
- 前後端完全分離，僅透過 API 通訊

**Scale/Scope**: 
- 約 10-15 個主要頁面 (前台: 首頁、商品列表、商品詳情、購物車、結帳、會員中心；後台: 商品管理、訂單管理、會員管理)
- 約 5-8 個核心實體 (User, Product, Order, OrderItem, Cart)
- 約 15-20 個 API 端點

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

✅ **I. 技術架構原則**: 已採用前後端分離架構，前端使用 Vue 3 + Tailwind CSS v4.* + PrimeVue v4.* + Pinia 並支援 RWD，後端使用 C# .NET 10 Web API + MSSQL，所有服務 Docker 容器化。

✅ **II. 功能需求原則**: 前台功能 (註冊、登入、瀏覽、購物車、結帳-貨到付款) 與後台功能 (商品管理、訂單管理、會員管理) 已納入規劃。

✅ **III. 開發與部署規範**: 使用 GitLab 版控 + feature branch 工作流，提交訊息使用繁體中文，Jenkins CI/CD 流程包含建置、測試、Docker 建置、部署，使用 Docker Compose 編排。

✅ **IV. 溝通與文件規範**: 所有文件使用繁體中文，規格文件使用 Markdown 格式，技術文件包含官網參考連結，API 文件描述端點、請求與回應格式。

✅ **V. 學習與品質原則**: 遵循各框架官方風格指南，前後端包含單元測試，程式碼通過 CI 流程檢核，專注於 Jenkins CI/CD、前後端分離、Docker 容器化、GitLab 版控學習目標。

## Project Structure

### Documentation (this feature)

```text
specs/001-shopping-website-cicd/
├── plan.md              # This file (/speckit.plan command output)
├── spec.md              # Feature specification (/speckit.specify command)
├── research.md          # Phase 0 output (/speckit.plan command)
├── data-model.md        # Phase 1 output (/speckit.plan command)
├── quickstart.md        # Phase 1 output (/speckit.plan command)
├── contracts/           # Phase 1 output (/speckit.plan command)
│   ├── auth-api.md
│   ├── products-api.md
│   ├── cart-api.md
│   └── orders-api.md
├── checklists/          # Quality checklists
│   └── requirements.md
└── tasks.md             # Phase 2 output (/speckit.tasks command - NOT created by /speckit.plan)
```

### Source Code (repository root)

```text
backend/
├── src/
│   ├── Controllers/        # API 控制器 (AuthController, ProductsController, OrdersController, CartController, AdminController)
│   ├── Models/             # 資料模型 (User, Product, Order, OrderItem, Cart)
│   ├── Services/           # 商業邏輯服務
│   ├── Data/               # DbContext 與資料庫相關
│   ├── DTOs/               # 資料傳輸物件
│   └── Program.cs          # 應用程式進入點
├── tests/
│   ├── UnitTests/          # 單元測試
│   └── IntegrationTests/   # 整合測試
├── Dockerfile              # 後端 Docker 映像定義
└── backend.csproj          # .NET 專案檔

frontend/
├── src/
│   ├── components/         # Vue 組件 (共用組件、前台組件、後台組件)
│   ├── pages/              # 頁面組件 (Home, Products, ProductDetail, Cart, Checkout, Admin/*)
│   ├── services/           # API 服務 (auth, products, cart, orders)
│   ├── stores/             # Pinia 狀態管理 (auth, cart, products)
│   ├── router/             # Vue Router 設定
│   └── App.vue            # 根組件
├── tests/                  # 前端測試
├── public/                 # 靜態資源
├── Dockerfile              # 前端 Docker 映像定義 (Nginx)
└── package.json            # Node.js 套件設定

docker/
├── docker-compose.yml      # 多容器編排定義
├── mssql/                  # MSSQL 初始化腳本
└── jenkins/                # Jenkins 配置 (如果需要容器化 Jenkins)

jenkins/
└── Jenkinsfile             # Jenkins Pipeline 定義 (建置、測試、部署)

.gitlab-ci.yml              # GitLab CI 配置 (觸發 Jenkins 或執行建置)
```

**Structure Decision**: 採用 Web application (前後端分離) 架構，將程式碼分為 backend/ 與 frontend/ 兩個主要目錄，並使用 Docker Compose 編排所有服務 (前端、後端、資料庫、Jenkins)。

## Complexity Tracking

> **Fill ONLY if Constitution Check has violations that must be justified**

無違反憲法原則，無需複雜度追蹤。
