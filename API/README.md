## launchSettings.json original

```
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:48216",
      "sslPort": 44354
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5092",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7230;http://localhost:5092",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## lanzar aplicación dentro de la carpeta API

```
dotnet run --launch-profile Development
```

Tu servidor ahora está corriendo en:
https://localhost:5001/.well-known/openid-configuration

Este endpoint describe automáticamente los paths de OAuth2.

```
{
"issuer": "https://localhost:5001",
"jwks_uri": "https://localhost:5001/.well-known/openid-configuration/jwks",
"authorization_endpoint": "https://localhost:5001/connect/authorize",
"token_endpoint": "https://localhost:5001/connect/token",
"userinfo_endpoint": "https://localhost:5001/connect/userinfo",
"end_session_endpoint": "https://localhost:5001/connect/endsession",
"check_session_iframe": "https://localhost:5001/connect/checksession",
"revocation_endpoint": "https://localhost:5001/connect/revocation",
"introspection_endpoint": "https://localhost:5001/connect/introspect",
"device_authorization_endpoint": "https://localhost:5001/connect/deviceauthorization",
"backchannel_authentication_endpoint": "https://localhost:5001/connect/ciba",
"pushed_authorization_request_endpoint": "https://localhost:5001/connect/par",
"require_pushed_authorization_requests": false,
"frontchannel_logout_supported": true,
"frontchannel_logout_session_supported": true,
"backchannel_logout_supported": true,
"backchannel_logout_session_supported": true,
"scopes_supported": [
"api1",
"offline_access"
],
"claims_supported": [],
"grant_types_supported": [
"authorization_code",
"client_credentials",
"refresh_token",
"implicit",
"urn:ietf:params:oauth:grant-type:device_code",
"urn:openid:params:grant-type:ciba"
],
"response_types_supported": [
"code",
"token",
"id_token",
"id_token token",
"code id_token",
"code token",
"code id_token token"
],
"response_modes_supported": [
"form_post",
"query",
"fragment"
],
"token_endpoint_auth_methods_supported": [
"client_secret_basic",
"client_secret_post"
],
"id_token_signing_alg_values_supported": [
"RS256"
],
"subject_types_supported": [
"public"
],
"code_challenge_methods_supported": [
"plain",
"S256"
],
"request_parameter_supported": true,
"request_object_signing_alg_values_supported": [
"RS256",
"RS384",
"RS512",
"PS256",
"PS384",
"PS512",
"ES256",
"ES384",
"ES512",
"HS256",
"HS384",
"HS512"
],
"prompt_values_supported": [
"none",
"login",
"consent",
"select_account"
],
"authorization_response_iss_parameter_supported": true,
"backchannel_token_delivery_modes_supported": [
"poll"
],
"backchannel_user_code_parameter_supported": true,
"dpop_signing_alg_values_supported": [
"RS256",
"RS384",
"RS512",
"PS256",
"PS384",
"PS512",
"ES256",
"ES384",
"ES512"
]
}
```

Probar el flujo client_credentials con un curl

```
curl -X POST https://localhost:5001/connect/token -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=client&client_secret=secret&grant_type=client_credentials&scope=api1" -k
```
```
{
  "access_token": "eyJhbGciOiJSUzI1NiIsImtpZCI6IjlDNERGRkE2MjlCNjdCMTA4QkIxNDJBNDExOTFDOEI5IiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIiwibmJmIjoxNzU0MDYwOTc5LCJpYXQiOjE3NTQwNjA5NzksImV4cCI6MTc1NDA2NDU3OSwic2NvcGUiOlsiYXBpMSJdLCJjbGllbnRfaWQiOiJjbGllbnQiLCJqdGkiOiJENUY2RTgzODk0NTg5QjBDNzA4MkQwQUIyOTZCRTcxRSJ9.BoqmWy1U6IsjOU9OcxE4no5T52sVYLwQzNyayJFJzbHxZC7uPYyDM5NsseZKum4cKGGOnIt2yZC6lfIItfBKF7eG1CSO4LQpUj1pAfVQkeOsOZ9CESFYuN3KroSvEC_N_jM10wrDApr9HmhIGrwVzovDNtTf3HS4Wj0Dyuz9MDhURLMmy3Bx6vv5Q8xiCC6Q4EdlgimFEfZXnIM46MmY1SXpCWtxWyNEFO3iQVLK3AARaGn3mEbyirSj1wEXgmQeT_Oqe0qZFBNwyyOe3jG9ZwgpFvlClRcVscbWruaSdZ5apa_caWRkNLFsS8lAYjg49dIEFCqxZ-sJCQ8qHN7EsQ",
  "expires_in": 3600,
  "token_type": "Bearer",
  "scope": "api1"
}
```