# Research: 企業購物網站與 Jenkins CI/CD 學習專案

**Created**: 2026-05-03
**Feature**: [spec.md](../spec.md)

## Technical Decisions

### Decision 1: 前端技術選型
**Decision**: Vue 3 (Composition API) + Tailwind CSS v4.* + PrimeVue v4.* + Pinia
**Rationale**: 憲法規範明確要求使用此技術堆疊。Vue 3 Composition API 提供更好的邏輯重用與 TypeScript 支援。Tailwind CSS v4.* 提供實用優先的樣式開發體驗。PrimeVue v4.* 提供豐富的企業級 UI 組件。Pinia 是 Vue 3 推薦的狀態管理方案。
**Alternatives considered**: 
- React + Tailwind + Material-UI (不符合憲法規範)
- Vue 3 + Bootstrap + Element Plus (不符合憲法規範)
- Angular + Angular Material (學習曲線較陡)

### Decision 2: 後端技術選型
**Decision**: C# .NET 10 Web API 採 RESTful API 設計模式
**Rationale**: 憲法規範明確要求使用 .NET 10。RESTful API 是業界標準的前後端通訊方式，易於理解和測試。.NET 10 提供高效能與跨平台能力。
**Alternatives considered**:
- Java Spring Boot (不符合憲法規範)
- Node.js Express (不符合憲法規範)
- Python Django REST Framework (效能較低)

### Decision 3: 資料庫選型
**Decision**: Microsoft SQL Server (MSSQL) 使用 Entity Framework Core
**Rationale**: 憲法規範明確要求使用 MSSQL。Entity Framework Core 是 .NET 官方的 ORM 解決方案，提供程式碼優先 (Code-First) 開發模式。
**Alternatives considered**:
- PostgreSQL (不符合憲法規範)
- MySQL (不符合憲法規範)
- SQLite (不適合企業級應用)

### Decision 4: 容器化與編排
**Decision**: Docker + Docker Compose
**Rationale**: 憲法規範要求所有服務 Docker 容器化部署，使用 Docker Compose 進行多容器編排。這是最簡單且廣泛使用的容器編排方案，適合學習專案。
**Alternatives considered**:
- Kubernetes (過於複雜，不適合學習專案)
- 直接使用 Docker 命令 (缺少編排能力)

### Decision 5: CI/CD 工具選型
**Decision**: Jenkins (建置、測試、Docker 映像建置、部署) + GitLab (版控)
**Rationale**: 憲法規範明確要求使用 Jenkins CI/CD 與 GitLab 版控。Jenkins 是業界標準的 CI/CD 工具，GitLab 提供完整的 DevOps 平台。
**Alternatives considered**:
- GitHub Actions + GitHub (不符合憲法規範)
- GitLab CI + GitLab (憲法要求使用 Jenkins)
- Azure DevOps (不符合憲法規範)

### Decision 6: 測試框架選型
**Decision**: 
- 前端: Vitest + Vue Test Utils
- 後端: xUnit + ASP.NET Core TestServer
- 整合測試: Docker Compose 完整環境測試
**Rationale**: Vitest 是 Vue 生態系推薦的測試框架，速度快且支援 Vue 組件測試。xUnit 是 .NET 官方的測試框架。Docker Compose 可以提供完整的測試環境。
**Alternatives considered**:
- 前端: Jest (Vue 3 官方推薦 Vitest)
- 後端: NUnit (xUnit 是 .NET 官方推薦)

## Best Practices Research

### Vue 3 + Tailwind CSS + PrimeVue 最佳實踐
- 使用 Composition API 的 `<script setup>` 語法
- 將可重用邏輯抽取為 Composable 函數
- 使用 Tailwind 的 `@apply` 指令抽取常用樣式組合
- PrimeVue 組件優先使用，必要時自定義樣式覆蓋
- Pinia store 按照功能模組拆分 (auth, products, cart, orders)

### .NET 10 Web API 最佳實踐
- 使用最小 API (Minimal APIs) 或控制器 (Controllers) 模式
- 採用分層架構：Controllers → Services → Repositories
- 使用 Entity Framework Core 的遷移 (Migrations) 管理資料庫結構
- 實作全域例外處理中介軟體 (Global Exception Middleware)
- 使用 JWT 或 Session 進行身份驗證

### Docker 最佳實踐
- 多階段建置 (Multi-stage build) 減小映像大小
- 前端使用 Nginx 作為靜態檔案伺服器
- 後端使用官方 .NET 10 Runtime 映像
- MSSQL 使用官方映像並掛載資料卷
- Docker Compose 定義網路讓容器互相通訊

### Jenkins Pipeline 最佳實踐
- 使用 Jenkinsfile 定義 Pipeline as Code
- 分階段執行：Build → Test → Build Docker Image → Deploy
- 使用憑證管理敏感資訊 (資料庫連線字串、API 金鑰)
- 建置失敗時發送通知 (Email/Slack)
- 保留建置紀錄與日誌

## Resolved Unknowns

所有技術選型均已根據憲法規範確定，無需額外澄清。
