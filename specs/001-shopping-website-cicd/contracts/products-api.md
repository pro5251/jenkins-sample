# API Contracts: 商品 API

**Base URL**: `/api/products`
**Description**: 商品瀏覽、搜尋、詳情查詢

---

## GET /api/products

**Description**: 取得商品列表 (分頁、搜尋、分類篩選)

**Query Parameters**:
- `page` (int, default: 1) - 頁數
- `page_size` (int, default: 20, max: 100) - 每頁數量
- `search` (string, optional) - 搜尋關鍵字 (商品名稱、描述)
- `category` (string, optional) - 商品分類篩選
- `min_price` (decimal, optional) - 最低價格篩選
- `max_price` (decimal, optional) - 最高價格篩選
- `sort_by` (string, optional) - 排序欄位 (price_asc, price_desc, name, created_at)
- `status` (string, default: 'active') - 商品狀態篩選

**Response 200 OK**:
```json
{
  "total_count": 100,
  "page": 1,
  "page_size": 20,
  "total_pages": 5,
  "products": [
    {
      "id": 1,
      "name": "商品名稱",
      "description": "商品描述",
      "price": 999.99,
      "stock": 50,
      "image_url": "https://example.com/image.jpg",
      "category": "電子產品",
      "status": "active",
      "created_at": "2026-05-03T10:00:00Z"
    }
  ]
}
```

**Response 400 Bad Request**:
```json
{
  "error": "Invalid query parameters",
  "details": ["page must be greater than 0"]
}
```

---

## GET /api/products/{id}

**Description**: 取得單一商品詳情

**Path Parameters**:
- `id` (int, required) - 商品 ID

**Response 200 OK**:
```json
{
  "id": 1,
  "name": "商品名稱",
  "description": "商品詳細描述",
  "price": 999.99,
  "stock": 50,
  "image_url": "https://example.com/image.jpg",
  "category": "電子產品",
  "status": "active",
  "created_at": "2026-05-03T10:00:00Z",
  "updated_at": "2026-05-03T11:00:00Z"
}
```

**Response 404 Not Found**:
```json
{
  "error": "Product not found"
}
```

---

## GET /api/products/categories

**Description**: 取得所有商品分類列表

**Response 200 OK**:
```json
{
  "categories": [
    "電子產品",
    "服飾",
    "家居用品",
    "書籍"
  ]
}
```

---

## POST /api/products (Admin Only)

**Description**: 新增商品 (後台管理)

**Headers**: `Authorization: Bearer {token}` (role: admin)

**Request Body**:
```json
{
  "name": "string (1-200 chars)",
  "description": "string (optional)",
  "price": "decimal (must be > 0)",
  "stock": "int (must be >= 0)",
  "image_url": "string (optional, valid URL)",
  "category": "string (required)"
}
```

**Response 201 Created**:
```json
{
  "id": 1,
  "name": "商品名稱",
  "description": "商品描述",
  "price": 999.99,
  "stock": 50,
  "image_url": "https://example.com/image.jpg",
  "category": "電子產品",
  "status": "active",
  "created_at": "2026-05-03T10:00:00Z"
}
```

**Response 400 Bad Request**:
```json
{
  "error": "Validation failed",
  "details": ["Price must be greater than 0"]
}
```

**Response 401 Unauthorized**:
```json
{
  "error": "Unauthorized"
}
```

**Response 403 Forbidden**:
```json
{
  "error": "Admin access required"
}
```

---

## PUT /api/products/{id} (Admin Only)

**Description**: 更新商品資訊 (後台管理)

**Headers**: `Authorization: Bearer {token}` (role: admin)

**Path Parameters**:
- `id` (int, required) - 商品 ID

**Request Body**:
```json
{
  "name": "string (optional)",
  "description": "string (optional)",
  "price": "decimal (optional, must be > 0)",
  "stock": "int (optional, must be >= 0)",
  "image_url": "string (optional)",
  "category": "string (optional)",
  "status": "string (optional, active/inactive)"
}
```

**Response 200 OK**:
```json
{
  "id": 1,
  "name": "更新後的商品名稱",
  "description": "更新後的描述",
  "price": 1099.99,
  "stock": 45,
  "image_url": "https://example.com/new-image.jpg",
  "category": "電子產品",
  "status": "active",
  "updated_at": "2026-05-03T12:00:00Z"
}
```

**Response 404 Not Found**:
```json
{
  "error": "Product not found"
}
```

---

## DELETE /api/products/{id} (Admin Only)

**Description**: 刪除商品 (後台管理，設定 status 為 inactive)

**Headers**: `Authorization: Bearer {token}` (role: admin)

**Path Parameters**:
- `id` (int, required) - 商品 ID

**Response 200 OK**:
```json
{
  "message": "Product deactivated successfully"
}
```

**Response 404 Not Found**:
```json
{
  "error": "Product not found"
}
```
