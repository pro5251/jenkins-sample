<!--
Sync Impact Report:
- Version change: NEW → 1.0.0
- Modified principles: N/A (initial creation)
- Added sections: Core Principles (5 principles), Reference Resources, Constitutional Amendment, Governance
- Removed sections: None
- Templates requiring updates:
  - ✅ .specify/templates/constitution-template.md (used as base)
  - ⚠ .specify/templates/plan-template.md (needs review for Constitution Check alignment)
  - ⚠ .specify/templates/spec-template.md (needs review for scope/requirements alignment)
  - ⚠ .specify/templates/tasks-template.md (needs review for principle-driven task types)
- Follow-up TODOs: Review and update dependent templates to align with new constitution principles
-->

# 企業購物網站與Jenkins CI/CD學習專案 Constitution

## Core Principles

### I. 技術架構原則
專案必須採用前後端分離架構。前端使用 Vue 3 (Composition API) + Tailwind CSS v4.* + PrimeVue v4.* + Pinia，並確保 RWD 響應式設計。後端使用 C# .NET 10 Web API 採 RESTful API 設計模式，資料庫使用 Microsoft SQL Server (MSSQL)。所有服務必須 Docker 容器化部署，前後端完全分離透過 API 通訊。

### II. 功能需求原則
前台必須提供客戶註冊與登入、商品瀏覽與搜尋、商品加入購物車、結帳功能（僅支援貨到付款）。後台必須提供商品上架管理、訂單管理、會員管理功能。所有功能須符合企業購物網站基本需求。

### III. 開發與部署規範
版本控制平台使用 GitLab，採用 feature branch 工作流，提交訊息必須使用繁體中文撰寫。CI/CD 工具使用 Jenkins，自動化流程包含：程式碼建置 (Build)、單元測試 (Test)、容器映像建置 (Docker Build)、部署至目標環境 (Deploy)。前端、後端、資料庫皆需建立 Dockerfile，使用 Docker Compose 進行多容器編排。

### IV. 溝通與文件規範
專案主要語言為繁體中文，適用範圍包含所有專案文件、程式碼註解、提交訊息、AI 溝通。所有規格文件使用 Markdown 格式，技術文件需包含官網參考連結，API 文件需完整描述端點、請求與回應格式。

### V. 學習與品質原則
專案目標為理解 Jenkins CI/CD 完整流程、掌握前後端分離架構實作、熟悉 Docker 容器化部署、學習 GitLab 版本控制最佳實踐。程式碼必須遵循各技術框架的官方風格指南，前後端需包含單元測試，程式碼需通過 CI 流程檢核。

## Reference Resources

- Jenkins 官方教學: https://www.jenkins.io/doc/tutorials/
- GitLab Docker 映像: https://hub.docker.com/u/gitlab
- Jenkins Docker 映像: https://hub.docker.com/r/jenkins/jenkins
- .NET 10 Docker 建置: https://learn.microsoft.com/zh-tw/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-10-0
- Vue.js 官方指南: https://vuejs.org/guide/introduction.html
- MSSQL Docker 映像: https://hub.docker.com/r/microsoft/mssql-server
- Tailwind CSS 中文文件: https://www.tailwindcss.cn/

## Constitutional Amendment

本憲法作為專案最高指導原則，任何技術決策不得違反本憲法規範。如需修正，需經過專案負責人審核並記錄修正理由。修正時需同步更新相關文件與模板。

## Governance

本憲法凌駕所有其他實踐規範。所有程式碼審查與 Pull Request 必須驗證是否符合本憲法原則。若實作複雜度增加，必須提出正當理由並記錄。使用 AGENTS.md 作為運行時開發指導文件。

**Version**: 1.0.0 | **Ratified**: 2026-05-03 | **Last Amended**: 2026-05-03
