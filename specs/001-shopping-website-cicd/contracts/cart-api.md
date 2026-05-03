# API Contracts: 購物車 API

**Base URL**: `/api/cart`
**Description**: 購物車管理功能

---

## GET /api/cart

**Description**: 取得當前用戶的購物車內容

**Headers**: `Authorization: Bearer {token}`

**Response 200 OK**:
```json
{
  "items": [
    {
      "id": 1,
      "product_id": 1,
      "product_name": "商品名稱",
      "price": 999.99,
      "quantity": 2,
      "subtotal": 1999.98,
      "image_url": "https://example.com/image.jpg",
      "stock": 50
    }
  ],
  "total_amount": 1999.98,
  "item_count": 2
}
```

**Response 401 Unauthorized**:
```json
{
  "error": "Unauthorized"
}
```

---

## POST /api/cart

**Description**: 添加商品至購物車

**Headers**: `Authorization: Bearer {token}`

**Request Body**:
```json
{
  "product_id": 1,
  "quantity": 2
}
```

**Response 201 Created**:
```json
{
  "id": 1,
  "product_id": 1,
  "product_name": "商品名稱",
  "price": 999.99,
  "quantity": 2,
  "subtotal": 1999.98,
  "stock": 50
}
```

**Response 400 Bad Request**:
```json
{
  "error": "Insufficient stock",
  "available_stock": 50
}
```

**Response 404 Not Found**:
```json
{
  "error": "Product not found"
}
```

---

## PUT /api/cart/{id}

**Description**: 更新購物車商品數量

**Headers**: `Authorization: Bearer {token}`

**Path Parameters**:
- `id` (int, required) - 購物車項目 ID

**Request Body**:
```json
{
  "quantity": 3
}
```

**Response 200 OK**:
```json
{
  "id": 1,
  "product_id": 1,
  "quantity": 3,
  "subtotal": 2999.97
}
```

**Response 400 Bad Request**:
```json
{
  "error": "Quantity must be greater than 0"
}
```

**Response 404 Not Found**:
```json
{
  "error": "Cart item not found"
}
```

---

## DELETE /api/cart/{id}

**Description**: 從購物車移除商品

**Headers**: `Authorization: Bearer {token}`

**Path Parameters**:
- `id` (int, required) - 購物車項目 ID

**Response 200 OK**:
```json
{
  "message": "Item removed from cart"
}
```

**Response 404 Not Found**:
```json
{
  "error": "Cart item not found"
}
```

---

## DELETE /api/cart

**Description**: 清空購物車

**Headers**: `Authorization: Bearer {token}`

**Response 200 OK**:
```json
{
  "message": "Cart cleared successfully"
}
```
