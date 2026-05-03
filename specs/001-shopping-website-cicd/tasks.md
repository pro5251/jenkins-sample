---
description: "Task list template for feature implementation"
---

# Tasks: 企業購物網站與 Jenkins CI/CD 學習專案

**Input**: Design documents from `/specs/001-shopping-website-cicd/`
**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Tests**: The examples below include test tasks. Tests are OPTIONAL - only include them if explicitly requested in the feature specification.

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)
- Include exact file paths in descriptions

## Path Conventions

- **Web app**: `backend/src/`, `frontend/src/`
- Paths shown below assume web app structure - adjust based on plan.md structure

<!-- 
  ============================================================================
  IMPORTANT: The tasks below are SAMPLE TASKS for illustration purposes only.
  
  The /speckit.tasks command MUST replace these with actual tasks based on:
  - User stories from spec.md (with their priorities P1, P2, P3...)
  - Feature requirements from plan.md
  - Entities from data-model.md
  - Endpoints from contracts/
  
  Tasks MUST be organized by user story so each story can be:
  - Implemented independently
  - Tested independently
  - Delivered as an MVP increment
  
  DO NOT keep these sample tasks in the generated tasks.md file.
  ============================================================================
-->

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic structure

- [ ] T001 Create project structure per implementation plan (backend/, frontend/, docker/, jenkins/)
- [ ] T002 [P] Initialize backend .NET 10 project with ASP.NET Core Web API dependencies
- [ ] T003 [P] Initialize frontend Vue 3 project with Vite + Tailwind CSS v4.* + PrimeVue v4.*
- [ ] T004 [P] Configure backend linting and formatting tools (.editorconfig)
- [ ] T005 [P] Configure frontend linting and formatting tools (ESLint, Prettier)
- [ ] T006 [P] Create .gitignore for backend and frontend
- [ ] T007 Create docker-compose.yml in docker/ with SQL Server, backend, frontend services
- [ ] T008 [P] Create Dockerfile for backend (.NET 10 multi-stage build)
- [ ] T009 [P] Create Dockerfile for frontend (Nginx static files)
- [ ] T010 [P] Create Jenkinsfile in jenkins/ with Build-Test-Docker-Deploy stages
- [ ] T011 Configure GitLab CI configuration (.gitlab-ci.yml for triggering Jenkins)

**Checkpoint**: Project structure ready - foundational phase can begin

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure that MUST be complete before ANY user story can be implemented

**⚠️ CRITICAL**: No user story work can begin until this phase is complete

- [ ] T012 Setup SQL Server database in Docker Compose with initial volume
- [ ] T013 [P] Configure Entity Framework Core with SQL Server provider in backend/src/Data/AppDbContext.cs
- [ ] T014 [P] Create database migration framework configuration in backend/
- [ ] T015 Implement authentication middleware (JWT/Session) in backend/src/Middleware/AuthMiddleware.cs
- [ ] T016 [P] Create base models/entities that all stories depend on in backend/src/Models/ (User.cs, Product.cs, Order.cs, OrderItem.cs, Cart.cs)
- [ ] T017 [P] Setup API routing and controller structure in backend/src/Controllers/
- [ ] T018 Configure CORS policy for frontend-backend communication in backend/src/Program.cs
- [ ] T019 [P] Setup environment configuration management (appsettings.json, .env files)
- [ ] T020 [P] Configure Pinia stores structure in frontend/src/stores/ (auth.js, products.js, cart.js, orders.js)
- [ ] T021 Setup Vue Router with lazy loading in frontend/src/router/index.js
- [ ] T022 [P] Create API service base configuration in frontend/src/services/api.js

**Checkpoint**: Foundation ready - user story implementation can now begin in parallel

---

## Phase 3: User Story 1 - 建立前後端分離購物網站基礎架構 (Priority: P1) 🎯 MVP

**Goal**: 建立前後端分離架構，前端使用 Vue 3 + Tailwind CSS + PrimeVue + Pinia，後端使用 .NET 10 Web API，資料庫使用 MSSQL，實作 RWD 響應式設計。

**Independent Test**: 可以透過啟動前端、後端、資料庫服務，驗證前後端 API 通訊是否正常，並檢視 RWD 響應式設計效果。

### Tests for User Story 1 (OPTIONAL - only if tests requested) ⚠️

> **NOTE: Write these tests FIRST, ensure they FAIL before implementation**

- [ ] T023 [P] [US1] Contract test for health check endpoint in backend/tests/contract/test_health_check.cs
- [ ] T024 [P] [US1] Integration test for database connection in backend/tests/integration/test_db_connection.cs
- [ ] T025 [P] [US1] Frontend component render test in frontend/tests/components/test_app.vue

### Implementation for User Story 1

**Backend Tasks:**

- [ ] T026 [P] [US1] Implement User model in backend/src/Models/User.cs
- [ ] T027 [P] [US1] Implement Product model in backend/src/Models/Product.cs
- [ ] T028 [P] [US1] Implement Order model in backend/src/Models/Order.cs
- [ ] T029 [P] [US1] Implement OrderItem model in backend/src/Models/OrderItem.cs
- [ ] T030 [P] [US1] Implement Cart model in backend/src/Models/Cart.cs
- [ ] T031 [US1] Create database migration for initial schema (dotnet ef migrations add InitialCreate)
- [ ] T032 [US1] Update database to apply migration (dotnet ef database update)
- [ ] T033 [P] [US1] Implement AuthController in backend/src/Controllers/AuthController.cs
- [ ] T034 [P] [US1] Implement ProductsController in backend/src/Controllers/ProductsController.cs
- [ ] T035 [P] [US1] Implement CartController in backend/src/Controllers/CartController.cs
- [ ] T036 [P] [US1] Implement OrdersController in backend/src/Controllers/OrdersController.cs
- [ ] T037 [US1] Implement AdminController in backend/src/Controllers/AdminController.cs
- [ ] T038 [US1] Add global exception handling middleware in backend/src/Middleware/ExceptionMiddleware.cs
- [ ] T039 [US1] Configure Swagger/OpenAPI documentation in backend/src/Program.cs

**Frontend Tasks:**

- [ ] T040 [P] [US1] Create App.vue root component with PrimeVue configuration in frontend/src/App.vue
- [ ] T041 [P] [US1] Setup Tailwind CSS v4.* configuration in frontend/tailwind.config.js
- [ ] T042 [P] [US1] Create layout components (Header, Footer, Sidebar) in frontend/src/components/layout/
- [ ] T043 [US1] Implement auth store (login, logout, token management) in frontend/src/stores/auth.js
- [ ] T044 [US1] Implement products store in frontend/src/stores/products.js
- [ ] T045 [US1] Implement cart store in frontend/src/stores/cart.js
- [ ] T046 [US1] Implement orders store in frontend/src/stores/orders.js
- [ ] T047 [P] [US1] Create auth API service in frontend/src/services/auth.js
- [ ] T048 [P] [US1] Create products API service in frontend/src/services/products.js
- [ ] T049 [P] [US1] Create cart API service in frontend/src/services/cart.js
- [ ] T050 [P] [US1] Create orders API service in frontend/src/services/orders.js
- [ ] T051 [US1] Implement RWD responsive layout testing across desktop and mobile viewports

**Checkpoint**: At this point, User Story 1 should be fully functional and testable independently

---

## Phase 4: User Story 2 - 實作購物網站前台功能 (Priority: P2)

**Goal**: 實作購物網站前台功能，包含客戶註冊與登入、商品瀏覽與搜尋、商品加入購物車、結帳功能 (僅支援貨到付款)。

**Independent Test**: 可以透過註冊新用戶、瀏覽商品、加入購物車、完成結帳流程來獨立測試前台功能。

### Tests for User Story 2 (OPTIONAL - only if tests requested) ⚠️

- [ ] T052 [P] [US2] Contract test for user registration endpoint in backend/tests/contract/test_register.cs
- [ ] T053 [P] [US2] Contract test for product search endpoint in backend/tests/contract/test_products.cs
- [ ] T054 [P] [US2] Integration test for checkout flow in backend/tests/integration/test_checkout.cs

### Implementation for User Story 2

**Backend Tasks:**

- [ ] T055 [US2] Implement user registration service with validation in backend/src/Services/AuthService.cs
- [ ] T056 [US2] Implement product search with filtering in backend/src/Services/ProductService.cs
- [ ] T057 [US2] Implement cart service (add, update, remove items) in backend/src/Services/CartService.cs
- [ ] T058 [US2] Implement order creation service (checkout) in backend/src/Services/OrderService.cs
- [ ] T059 [US2] Add stock validation before checkout in backend/src/Services/OrderService.cs
- [ ] T060 [US2] Implement password hashing and validation in backend/src/Services/AuthService.cs

**Frontend Tasks:**

- [ ] T061 [P] [US2] Create RegisterPage in frontend/src/pages/RegisterPage.vue
- [ ] T062 [P] [US2] Create LoginPage in frontend/src/pages/LoginPage.vue
- [ ] T063 [US2] Create HomePage with product listing in frontend/src/pages/HomePage.vue
- [ ] T064 [US2] Create ProductDetailPage in frontend/src/pages/ProductDetailPage.vue
- [ ] T065 [US2] Create CartPage in frontend/src/pages/CartPage.vue
- [ ] T066 [US2] Create CheckoutPage in frontend/src/pages/CheckoutPage.vue
- [ ] T067 [US2] Create UserProfilePage in frontend/src/pages/UserProfilePage.vue
- [ ] T068 [P] [US2] Implement ProductCard component in frontend/src/components/ProductCard.vue
- [ ] T069 [P] [US2] Implement CartItem component in frontend/src/components/CartItem.vue
- [ ] T070 [US2] Add search and filter functionality to HomePage
- [ ] T071 [US2] Implement form validation for registration and checkout

**Checkpoint**: At this point, User Stories 1 AND 2 should both work independently

---

## Phase 5: User Story 3 - 實作購物網站後台管理功能 (Priority: P2)

**Goal**: 實作購物網站後台功能，包含商品上架管理、訂單管理、會員管理功能。

**Independent Test**: 可以透過管理者登入後台、上架新商品、查看訂單、管理會員來獨立測試後台功能。

### Tests for User Story 3 (OPTIONAL - only if tests requested) ⚠️

- [ ] T072 [P] [US3] Contract test for admin product management in backend/tests/contract/test_admin_products.cs
- [ ] T073 [P] [US3] Contract test for admin order management in backend/tests/contract/test_admin_orders.cs

### Implementation for User Story 3

**Backend Tasks:**

- [ ] T074 [US3] Implement admin product management service in backend/src/Services/AdminService.cs
- [ ] T075 [US3] Implement order status update service in backend/src/Services/OrderService.cs
- [ ] T076 [US3] Implement user management service for admin in backend/src/Services/AdminService.cs
- [ ] T077 [US3] Add admin role authorization middleware in backend/src/Middleware/AdminAuthMiddleware.cs

**Frontend Tasks:**

- [ ] T078 [P] [US3] Create AdminLayout in frontend/src/components/layout/AdminLayout.vue
- [ ] T079 [US3] Create AdminProductsPage in frontend/src/pages/admin/AdminProductsPage.vue
- [ ] T080 [US3] Create AdminOrdersPage in frontend/src/pages/admin/AdminOrdersPage.vue
- [ ] T081 [US3] Create AdminUsersPage in frontend/src/pages/admin/AdminUsersPage.vue
- [ ] T082 [P] [US3] Implement ProductForm component for add/edit in frontend/src/components/admin/ProductForm.vue
- [ ] T083 [US3] Implement OrderDetail component in frontend/src/components/admin/OrderDetail.vue
- [ ] T084 [US3] Add admin navigation and sidebar menu

**Checkpoint**: All user stories should now be independently functional

---

## Phase 6: User Story 4 - 建立 Jenkins CI/CD 自動化部署流程 (Priority: P1)

**Goal**: 使用 GitLab 進行程式碼版控，建立 Jenkins CI/CD 流程實現自動化建置、測試、容器化與部署。

**Independent Test**: 可以透過提交程式碼至 GitLab，觀察 Jenkins 自動觸發建置、測試、Docker 映像建置與部署流程。

### Tests for User Story 4 (OPTIONAL - only if tests requested) ⚠️

- [ ] T085 [P] [US4] Test Jenkins pipeline syntax in jenkins/Jenkinsfile
- [ ] T086 [P] [US4] Test Docker Compose orchestration in docker/docker-compose.yml

### Implementation for User Story 4

- [ ] T087 [US4] Configure Jenkins with GitLab webhook integration
- [ ] T088 [US4] Setup Jenkins credentials for Docker Hub / registry
- [ ] T089 [US4] Configure Jenkins pipeline stages: Build → Test → Docker Build → Deploy
- [ ] T090 [US4] Add unit test execution step in Jenkinsfile
- [ ] T091 [US4] Add Docker image build and push step in Jenkinsfile
- [ ] T092 [US4] Add deployment step to target environment in Jenkinsfile
- [ ] T093 [US4] Configure Docker Compose for production deployment in docker/docker-compose.prod.yml
- [ ] T094 [US4] Add notification (email/Slack) on build failure in Jenkinsfile
- [ ] T095 [US4] Test complete CI/CD flow with sample commit to GitLab

**Checkpoint**: At this point, full CI/CD pipeline should be functional and testable

---

## Phase 7: Polish & Cross-Cutting Concerns

**Purpose**: Improvements that affect multiple user stories

- [ ] T096 [P] Documentation updates in docs/ (update quickstart.md with actual experiences)
- [ ] T097 Code cleanup and refactoring across backend and frontend
- [ ] T098 Performance optimization across all stories (database indexing, API response caching)
- [ ] T099 [P] Additional unit tests (if requested) in backend/tests/unit/ and frontend/tests/
- [ ] T100 Security hardening (input validation, SQL injection prevention, XSS protection)
- [ ] T101 [P] Add logging and monitoring (Serilog for backend, console logging for frontend)
- [ ] T102 Run quickstart.md validation and update based on actual setup experience
- [ ] T103 [P] Add error handling improvements across all user stories
- [ ] T104 Add accessibility (a11y) improvements for RWD design

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately
- **Foundational (Phase 2)**: Depends on Setup completion - BLOCKS all user stories
- **User Stories (Phase 3+)**: All depend on Foundational phase completion
  - User stories can then proceed in parallel (if staffed)
  - Or sequentially in priority order (P1 → P2 → P3)
- **User Story 4 (Phase 6)**: Depends on Setup completion, can run parallel with other stories after foundation
- **Polish (Final Phase)**: Depends on all desired user stories being complete

### User Story Dependencies

- **User Story 1 (P1)**: Can start after Foundational (Phase 2) - No dependencies on other stories
- **User Story 2 (P2)**: Can start after Foundational (Phase 2) - May integrate with US1 but should be independently testable
- **User Story 3 (P2)**: Can start after Foundational (Phase 2) - May integrate with US1/US2 but should be independently testable
- **User Story 4 (P1)**: Can start after Foundational (Phase 2) - May integrate with US1 for testing CI/CD

### Within Each User Story

- Tests (if included) MUST be written and FAIL before implementation
- Models before services
- Services before controllers/endpoints
- Core implementation before integration
- Story complete before moving to next priority

### Parallel Opportunities

- All Setup tasks marked [P] can run in parallel
- All Foundational tasks marked [P] can run in parallel (within Phase 2)
- Once Foundational phase completes, all user stories can start in parallel (if team capacity allows)
- All tests for a user story marked [P] can run in parallel
- Models within a story marked [P] can run in parallel
- Different user stories can be worked on in parallel by different team members
- User Story 4 tasks can run parallel with US2/US3 after foundation

---

## Parallel Example: User Story 1

```bash
# Launch all model tasks for User Story 1 together:
Task: "Implement User model in backend/src/Models/User.cs"
Task: "Implement Product model in backend/src/Models/Product.cs"
Task: "Implement Order model in backend/src/Models/Order.cs"
Task: "Implement OrderItem model in backend/src/Models/OrderItem.cs"
Task: "Implement Cart model in backend/src/Models/Cart.cs"

# Launch all API service tasks for frontend together:
Task: "Create auth API service in frontend/src/services/auth.js"
Task: "Create products API service in frontend/src/services/products.js"
Task: "Create cart API service in frontend/src/services/cart.js"
Task: "Create orders API service in frontend/src/services/orders.js"
```

---

## Implementation Strategy

### MVP First (User Story 1 Only)

1. Complete Phase 1: Setup
2. Complete Phase 2: Foundational (CRITICAL - blocks all stories)
3. Complete Phase 3: User Story 1
4. **STOP and VALIDATE**: Test User Story 1 independently
5. Deploy/demo if ready

### Incremental Delivery

1. Complete Setup + Foundational → Foundation ready
2. Add User Story 1 → Test independently → Deploy/Demo (MVP!)
3. Add User Story 4 → Test independently → Deploy/Demo (CI/CD working)
4. Add User Story 2 → Test independently → Deploy/Demo
5. Add User Story 3 → Test independently → Deploy/Demo
6. Each story adds value without breaking previous stories

### Parallel Team Strategy

With multiple developers:

1. Team completes Setup + Foundational together
2. Once Foundational is done:
   - Developer A: User Story 1
   - Developer B: User Story 4
   - Developer C: User Story 2
   - Developer D: User Story 3
3. Stories complete and integrate independently

---

## Notes

- [P] tasks = different files, no dependencies
- [Story] label maps task to specific user story for traceability
- Each user story should be independently completable and testable
- Verify tests fail before implementing
- Commit after each task or logical group
- Stop at any checkpoint to validate story independently
- Avoid: vague tasks, same file conflicts, cross-story dependencies that break independence
- All tasks follow checklist format with ID, [P] marker, [Story] label, file path
- Total tasks: 104 (adjust based on actual implementation needs)
