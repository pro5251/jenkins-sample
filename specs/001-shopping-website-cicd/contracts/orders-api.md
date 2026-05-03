# API Contracts: 訂單 API

**Base URL**: `/api/orders`
**Description**: 訂單管理與結帳功能

---

## POST /api/orders/checkout

**Description**: 從購物車結帳生成訂單

**Headers**: `Authorization: Bearer {token}`

**Request Body**:
```json
{
  "shipping_address": "送貨地址",
  "contact_phone": "聯絡電話"
}
```

**Response 201 Created**:
```json
{
  "order_id": 1,
  "user_id": 1,
  "total_amount": 1999.98,
  "status": "pending",
  "payment_method": "貨到付款",
  "shipping_address": "送貨地址",
  "contact_phone": "聯絡電話",
  "items": [
    {
      "product_name": "商品名稱",
      "quantity": 2,
      "price": 999.99,
      "subtotal": 1999.98
    }
  ],
  "created_at": "2026-05-03T10:00:00Z"
}
```

**Response 400 Bad Request**:
```json
{
  "error": "Cart is empty"
}
```

**Response 401 Unauthorized**:
```json
{
  "error": "Unauthorized"
}
```

---

## GET /api/orders

**Description**: 取得用戶的訂單列表

**Headers**: `Authorization: Bearer {token}`

**Query Parameters**:
- `page` (int, default: 1) - 頁數
- `page_size` (int, default: 20) - 每頁數量
- `status` (string, optional) - 篩選訂單狀態

**Response 200 OK**:
```json
{
  "total_count": 10,
  "page": 1,
  "page_size": 20,
  "orders": [
    {
      "order_id": 1,
      "total_amount": 1999.98,
      "status": "pending",
      "payment_method": "貨到付款",
      "created_at": "2026-05-03T10:00:00Z"
    }
  ]
}
```

---

## GET /api/orders/{id}

**Description**: 取得單一訂單詳情

**Headers**: `Authorization: Bearer {token}`

**Path Parameters**:
- `id` (int, required) - 訂單 ID

**Response 200 OK**:
```json
{
  "order_id": 1,
  "user_id": 1,
  "total_amount": 1999.98,
  "status": "pending",
  "payment_method": "貨到付款",
  "shipping_address": "送貨地址",
  "contact_phone": "聯絡電話",
  "items": [
    {
      "product_name": "商品名稱",
      "quantity": 2,
      "price": 999.99,
      "subtotal": 1999.98
    }
  ],
  "created_at": "2026-05-03T10:00:00Z",
  "updated_at": "2026-05-03T10:00:00Z"
}
```

**Response 404 Not Found**:
```json
{
  "error": "Order not found"
}
```

---

## PUT /api/orders/{id}/status (Admin Only)

**Description**: 更新訂單狀態 (後台管理)

**Headers**: `Authorization: Bearer {token}` (role: admin)

**Path Parameters**:
- `id` (int, required) - 訂單 ID

**Request Body**:
```json
{
  "status": "confirmed"  // pending/confirmed/shipped/delivered/cancelled
}
```

**Response 200 OK**:
```json
{
  "order_id": 1,
  "status": "confirmed",
  "updated_at": "2026-05-03T11:00:00Z"
}
```

**Response 400 Bad Request**:
```json
{
  "error": "Invalid status transition"
}
```
