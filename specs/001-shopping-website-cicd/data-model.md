# Data Model: 企業購物網站與 Jenkins CI/CD 學習專案

**Created**: 2026-05-03
**Feature**: [spec.md](../spec.md)

## Entities

### User (用戶)

**Description**: 系統使用者，包含一般用戶與管理者兩種角色。

**Attributes**:
- `id` (int, PK, identity) - 用戶唯一識別碼
- `username` (nvarchar(50), unique, not null) - 用戶名稱
- `email` (nvarchar(100), unique, not null) - 電子郵件
- `password_hash` (nvarchar(255), not null) - 密碼雜湊值
- `role` (nvarchar(20), not null, default: 'customer') - 角色 (customer/admin)
- `created_at` (datetime2, not null, default: GETDATE()) - 建立時間
- `updated_at` (datetime2, null) - 更新時間
- `is_active` (bit, not null, default: 1) - 是否啟用

**Validation Rules**:
- username: 3-50 字元，只能包含字母、數字、底線
- email: 必須符合電子郵件格式
- password: 至少 8 字元，包含大小寫字母與數字
- role: 只能為 'customer' 或 'admin'

**Relationships**:
- One-to-Many: User → Order (一個用戶可以有多個訂單)
- One-to-Many: User → Cart (一個用戶可以有多個購物車項目)

---

### Product (商品)

**Description**: 購物網站銷售的商品。

**Attributes**:
- `id` (int, PK, identity) - 商品唯一識別碼
- `name` (nvarchar(200), not null) - 商品名稱
- `description` (nvarchar(max), null) - 商品描述
- `price` (decimal(18,2), not null) - 商品價格
- `stock` (int, not null, default: 0) - 庫存數量
- `image_url` (nvarchar(500), null) - 商品圖片網址
- `category` (nvarchar(100), not null) - 商品分類
- `status` (nvarchar(20), not null, default: 'active') - 狀態 (active/inactive)
- `created_at` (datetime2, not null, default: GETDATE()) - 建立時間
- `updated_at` (datetime2, null) - 更新時間

**Validation Rules**:
- name: 1-200 字元
- price: 必須大於 0
- stock: 必須大於或等於 0
- status: 只能為 'active' 或 'inactive'

**Relationships**:
- One-to-Many: Product → OrderItem (一個商品可以出現在多個訂單項目中)
- One-to-Many: Product → Cart (一個商品可以出現在多個購物車項目中)

---

### Order (訂單)

**Description**: 用戶的購物訂單。

**Attributes**:
- `id` (int, PK, identity) - 訂單唯一識別碼
- `user_id` (int, FK, not null) - 用戶 ID (參照 User.id)
- `total_amount` (decimal(18,2), not null) - 訂單總金額
- `status` (nvarchar(20), not null, default: 'pending') - 訂單狀態 (pending/confirmed/shipped/delivered/cancelled)
- `payment_method` (nvarchar(50), not null, default: '貨到付款') - 付款方式
- `shipping_address` (nvarchar(500), not null) - 送貨地址
- `contact_phone` (nvarchar(20), not null) - 聯絡電話
- `created_at` (datetime2, not null, default: GETDATE()) - 建立時間
- `updated_at` (datetime2, null) - 更新時間

**Validation Rules**:
- total_amount: 必須大於 0
- status: 只能為 'pending', 'confirmed', 'shipped', 'delivered', 'cancelled'
- payment_method: 目前僅支援 '貨到付款'
- shipping_address: 不得為空
- contact_phone: 必須符合電話號碼格式

**State Transitions**:
```
pending → confirmed (管理者確認訂單)
confirmed → shipped (管理者出貨)
shipped → delivered (用戶收貨)
pending → cancelled (用戶或管理者取消訂單)
confirmed → cancelled (管理者取消訂單)
```

**Relationships**:
- Many-to-One: Order → User (多個訂單屬於一個用戶)
- One-to-Many: Order → OrderItem (一個訂單可以有多個訂單項目)

---

### OrderItem (訂單項目)

**Description**: 訂單中的商品項目。

**Attributes**:
- `id` (int, PK, identity) - 訂單項目唯一識別碼
- `order_id` (int, FK, not null) - 訂單 ID (參照 Order.id)
- `product_id` (int, FK, not null) - 商品 ID (參照 Product.id)
- `quantity` (int, not null) - 購買數量
- `price` (decimal(18,2), not null) - 購買時的單價
- `created_at` (datetime2, not null, default: GETDATE()) - 建立時間

**Validation Rules**:
- quantity: 必須大於 0
- price: 必須大於 0

**Relationships**:
- Many-to-One: OrderItem → Order (多個訂單項目屬於一個訂單)
- Many-to-One: OrderItem → Product (多個訂單項目參照一個商品)

---

### Cart (購物車)

**Description**: 用戶的購物車臨時保存項目。

**Attributes**:
- `id` (int, PK, identity) - 購物車項目唯一識別碼
- `user_id` (int, FK, not null) - 用戶 ID (參照 User.id)
- `product_id` (int, FK, not null) - 商品 ID (參照 Product.id)
- `quantity` (int, not null, default: 1) - 商品數量
- `created_at` (datetime2, not null, default: GETDATE()) - 加入購物車時間
- `updated_at` (datetime2, null) - 更新時間

**Validation Rules**:
- quantity: 必須大於 0，且不得超過商品庫存

**Relationships**:
- Many-to-One: Cart → User (多個購物車項目屬於一個用戶)
- Many-to-One: Cart → Product (多個購物車項目參照一個商品)

**Note**: 購物車項目在結帳成功後會被清空，並轉換為 Order 與 OrderItem。

---

## Entity Relationship Diagram (文字描述)

```
User (1) ──── (N) Order
User (1) ──── (N) Cart

Order (1) ──── (N) OrderItem
Product (1) ──── (N) OrderItem

Product (1) ──── (N) Cart
```

## Database Constraints

- **Primary Keys**: 所有實體的 `id` 皆為主鍵
- **Foreign Keys**:
  - Order.user_id → User.id (CASCADE DELETE)
  - OrderItem.order_id → Order.id (CASCADE DELETE)
  - OrderItem.product_id → Product.id (RESTRICT DELETE)
  - Cart.user_id → User.id (CASCADE DELETE)
  - Cart.product_id → Product.id (RESTRICT DELETE)
- **Unique Constraints**:
  - User.username (唯一)
  - User.email (唯一)
- **Check Constraints**:
  - Product.price > 0
  - Product.stock >= 0
  - OrderItem.quantity > 0
  - OrderItem.price > 0
  - Cart.quantity > 0

## Indexing Strategy

- User: 在 `email` 與 `username` 上建立唯一索引
- Product: 在 `category` 與 `status` 上建立索引以加速查詢
- Order: 在 `user_id` 與 `status` 上建立索引
- OrderItem: 在 `order_id` 與 `product_id` 上建立索引
- Cart: 在 `user_id` 與 `product_id` 上建立索引

## Seed Data (開發用)

建議在開發環境中新增以下初始資料：
- 一個 admin 用戶 (role: 'admin')
- 3-5 個測試用戶 (role: 'customer')
- 10-20 個測試商品，涵蓋不同分類
- 部分商品設定為 inactive 以測試過濾功能
