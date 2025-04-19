# AuthenticationBFF
Provee endpoints de autenticaciÃ³n de usuarios.
## Endpoints
| MÃ©todo | Ruta | DescripciÃ³n |
|--------|------|-------------|
| GET | /auth/status | Verifica estado del servicio |
| POST | /auth/login | Realiza login con usuario y contraseÃ±a |

## Diagrama (Mermaid)
```mermaid
graph TD
    Client --> AuthenticationBFF
    AuthenticationBFF -->|GET| _auth_status[/auth/status]
    AuthenticationBFF -->|POST| _auth_login[/auth/login]
```
