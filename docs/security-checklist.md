# Security Hardening Checklist

## Input Validation
- [x] Validate all user inputs on server side
- [x] Sanitize inputs to prevent XSS
- [x] Validate data types and formats

## Authentication & Authorization
- [x] Use strong password requirements
- [x] Hash passwords with bcrypt/Argon2
- [x] Implement JWT token expiration
- [x] Validate tokens on every request

## Database Security
- [x] Use parameterized queries (EF Core handles this)
- [x] Limit database user permissions
- [x] Encrypt sensitive data

## API Security
- [x] Implement rate limiting
- [x] Use HTTPS everywhere
- [x] Validate CORS origins

## Error Handling
- [x] Don't expose sensitive info in errors
- [x] Log security events
- [x] Implement global exception handling
