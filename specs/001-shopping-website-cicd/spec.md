# Feature Specification: 企業購物網站與 Jenkins CI/CD 學習專案

**Feature Branch**: `001-shopping-website-cicd`  
**Created**: 2026-05-03  
**Status**: Draft  
**Input**: User description: "實作企業購物網站與透過 Jenkins CI/CD 進行的上版流程,並從中了解整個過程加以學習"

## User Scenarios & Testing *(mandatory)*

### User Story 1 - 建立前後端分離購物網站基礎架構 (Priority: P1)

建立前後端分離的企業購物網站，前端使用 Vue 3 + Tailwind CSS v4.* + PrimeVue v4.* + Pinia，後端使用 C# .NET 10 Web API，資料庫使用 MSSQL，實現 RWD 響應式設計。

**Why this priority**: 這是整個專案的核心基礎，必須先建立技術架構才能開發功能。

**Independent Test**: 可以透過啟動前端、後端、資料庫服務，驗證前後端 API 通訊是否正常，並檢視 RWD 響應式設計效果。

**Acceptance Scenarios**:

1. **Given** 專案初始化完成, **When** 啟動前端開發伺服器, **Then** 看到 Vue 3 + Tailwind CSS + PrimeVue 首頁並支援 RWD
2. **Given** 專案初始化完成, **When** 啟動後端 API 服務, **Then** 看到 .NET 10 Web API 運行並可接收 HTTP 請求
3. **Given** 前後端服務運行中, **When** 前端發送 API 請求, **Then** 後端正確回應並建立資料庫連線

---

### User Story 2 - 實作購物網站前台功能 (Priority: P2)

實作購物網站前台功能，包含客戶註冊與登入、商品瀏覽與搜尋、商品加入購物車、結帳功能 (僅支援貨到付款)。

**Why this priority**: 這是購物網站的核心功能，讓用戶能夠實際使用網站進行購物。

**Independent Test**: 可以透過註冊新用戶、瀏覽商品、加入購物車、完成結帳流程來獨立測試前台功能。

**Acceptance Scenarios**:

1. **Given** 用戶未登入, **When** 訪問註冊頁面並填寫資料, **Then** 成功建立帳號並收到確認
2. **Given** 用戶已登入, **When** 瀏覽商品頁面, **Then** 看到商品列表並可使用搜尋功能
3. **Given** 用戶已登入並在商品頁面, **When** 點擊加入購物車, **Then** 商品成功加入購物車並顯示數量
4. **Given** 用戶已登入且購物車有商品, **When** 進入結帳頁面並確認, **Then** 訂單建立成功並顯示貨到付款資訊

---

### User Story 3 - 實作購物網站後台管理功能 (Priority: P2)

實作購物網站後台功能，包含商品上架管理、訂單管理、會員管理功能。

**Why this priority**: 後台管理是電商網站營運的必要功能，讓管理者能夠管理網站內容。

**Independent Test**: 可以透過管理者登入後台、上架新商品、查看訂單、管理會員來獨立測試後台功能。

**Acceptance Scenarios**:

1. **Given** 管理者已登入後台, **When** 填寫商品資訊並上架, **Then** 商品成功上架並在前台可見
2. **Given** 管理者已登入後台, **When** 查看訂單列表, **Then** 看到所有客戶訂單並可查看詳情
3. **Given** 管理者已登入後台, **When** 查看會員列表, **Then** 看到所有註冊會員並可進行管理操作

---

### User Story 4 - 建立 Jenkins CI/CD 自動化部署流程 (Priority: P1)

使用 GitLab 進行程式碼版控，建立 Jenkins CI/CD 流程實現自動化建置、測試、容器化與部署。

**Why this priority**: 這是專案的核心學習目標，透過實作 CI/CD 流程來理解現代化 DevOps 實踐。

**Independent Test**: 可以透過提交程式碼至 GitLab，觀察 Jenkins 自動觸發建置、測試、Docker 映像建置與部署流程。

**Acceptance Scenarios**:

1. **Given** 程式碼提交至 GitLab, **When** Jenkins 檢測到變更, **Then** 自動觸發建置流程並執行單元測試
2. **Given** 建置與測試成功, **When** Jenkins 執行部署階段, **Then** 自動建置 Docker 映像並部署至目標環境
3. **Given** 所有服務運行中, **When** 訪問網站, **Then** 看到最新版本的購物網站

---

### Edge Cases

- 當 MSSQL 資料庫連線失敗時，系統應顯示友善錯誤訊息並記錄日誌
- 當 API 請求超時時，前端應顯示載入中狀態並有重試機制
- 當購物車商品庫存不足時，結帳流程應阻止並提示用戶
- 當 Jenkins 部署失敗時，應有回滾機制或通知管理員

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: 系統 MUST 採用前後端分離架構，前端使用 Vue 3 + Tailwind CSS v4.* + PrimeVue v4.* + Pinia
- **FR-002**: 系統 MUST 使用 C# .NET 10 Web API 建立 RESTful API 後端服務
- **FR-003**: 系統 MUST 使用 Microsoft SQL Server (MSSQL) 作為資料庫
- **FR-004**: 系統 MUST 實作 RWD 響應式設計，支援桌面與行動裝置
- **FR-005**: 系統 MUST 提供客戶註冊與登入功能
- **FR-006**: 系統 MUST 提供商品瀏覽、搜尋、加入購物車功能
- **FR-007**: 系統 MUST 提供結帳功能，僅支援貨到付款方式
- **FR-008**: 系統 MUST 提供後台商品上架、訂單管理、會員管理功能
- **FR-009**: 系統 MUST 使用 GitLab 進行程式碼版控，採用 feature branch 工作流
- **FR-010**: 系統 MUST 使用 Jenkins 建立 CI/CD 流程，包含建置、測試、Docker 映像建置、部署
- **FR-011**: 系統 MUST 將所有服務 Docker 容器化，使用 Docker Compose 編排
- **FR-012**: 系統 MUST 使用繁體中文作為主要溝通與文件語言

### Key Entities *(include if feature involves data)*

- **User (用戶)**: 包含 id, username, email, password, role (customer/admin), created_at 等屬性
- **Product (商品)**: 包含 id, name, description, price, stock, image_url, category, status, created_at 等屬性
- **Order (訂單)**: 包含 id, user_id, total_amount, status, payment_method (貨到付款), created_at 等屬性
- **OrderItem (訂單項目)**: 包含 id, order_id, product_id, quantity, price 等屬性
- **Cart (購物車)**: 包含 id, user_id, product_id, quantity, created_at 等屬性

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: 用戶可在 3 分鐘內完成註冊並開始瀏覽商品
- **SC-002**: 系統可處理 100 個並發用戶進行購物操作而無明顯效能下降
- **SC-003**: 90% 的用戶操作 (註冊、瀏覽、加入購物車、結帳) 可首次嘗試成功
- **SC-004**: Jenkins CI/CD 流程可在程式碼提交後 10 分鐘內完成建置、測試與部署
- **SC-005**: 所有頁面在桌面 (1920x1080) 與行動裝置 (375x667) 皆正常顯示與操作

## Assumptions

- 用戶具有穩定的網際網路連線能力
- 暫不支援第三方支付，僅提供貨到付款方式
- 使用 Docker Desktop 作為本地開發與部署環境
- Jenkins 與 GitLab 將在相同網路環境中運行 (可透過 Docker 容器或本地安裝)
- 暫不實作進階搜尋功能，僅提供基本關鍵字搜尋
- 後台管理暫不實作權限分級，僅區分一般用戶與管理者
