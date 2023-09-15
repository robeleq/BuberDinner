## API

# Get All Dinners
- Request
``` js
GET {{host}}/api/dinners
Authentication: Bearer {{token}}
```

``` json
{
  "firstName": "john",
  "lastName": "doe",
  "email": "john@email.com",
  "password": "123"
}
```

- Respnse
200 OK
``` json
{
  "id": "2d901554-479e-4d2c-9ab6-b5edf89193ff",
  "firstName": "john",
  "lastName": "doe",
  "email": "john@email.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9....oIslqwL1fKWWVXXB_sw46QQ"
}
```

# Login
- Request
POST {{host}}/auth/login
``` json
{
  "email": "john@email.com",
  "password": "123"
}
```

- Respnse
200 OK
``` json
{
  "id": "2d901554-479e-4d2c-9ab6-b5edf89193ff",
  "firstName": "john",
  "lastName": "doe",
  "email": "john@email.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9....oIslqwL1fKWWVXXB_sw46QQ"
}
```