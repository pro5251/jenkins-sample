# API Contracts: 認證 API

**Base URL**: `/api/auth`
**Description**: 用戶註冊、登入、登出功能

---

## POST /api/auth/register

**Description**: 用戶註冊新帳號

**Request Body**:
```json
{
  "username": "string (3-50 chars, alphanumeric + underscore)",
  "email": "string (valid email format)",
  "password": "string (min 8 chars, must contain letters and numbers)",
  "confirm_password": "string (must match password)"
}
```

**Response 201 Created**:
```json
{
  "user_id": 1,
  "username": "john_doe",
  "email": "john@example.com",
  "role": "customer",
  "created_at": "2026-05-03T10:00:00Z"
}
```

**Response 400 Bad Request**:
```json
{
  "error": "Validation failed",
  "details": [
    "Username already exists",
    "Email already registered",
    "Password does not meet requirements"
  ]
}
```

---

## POST /api/auth/login

**Description**: 用戶登入取得 session/token

**Request Body**:
```json
{
  "email": "string",
  "password": "string"
}
```

**Response 200 OK**:
```json
{
  "user_id": 1,
  "username": "john_doe",
  "email": "john@example.com",
  "role": "customer",
  "token": "jwt-token-string (if using JWT)",
  "expires_at": "2026-05-03T11:00:00Z"
}
```

**Response 401 Unauthorized**:
```json
{
  "error": "Invalid credentials"
}
```

---

## POST /api/auth/logout

**Description**: 用戶登出 (清除 session/token)

**Headers**: `Authorization: Bearer {token}` (if using JWT)

**Response 200 OK**:
```json
{
  "message": "Logged out successfully"
}
```

**Response 401 Unauthorized**:
```json
{
  "error": "Invalid or expired token"
}
```

---

## GET /api/auth/me

**Description**: 取得當前登入用戶資訊

**Headers**: `Authorization: Bearer {token}` (if using JWT)

**Response 200 OK**:
```json
{
  "user_id": 1,
  "username": "john_doe",
  "email": "john@example.com",
  "role": "customer",
  "created_at": "2026-05-03T10:00:00Z"
}
```

**Response 401 Unauthorized**:
```json
{
  "error": "Unauthorized"
}
```
