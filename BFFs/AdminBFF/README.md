# AdminBFF
Funciones administrativas y de gestiÃ³n de usuarios.
## Endpoints
| MÃ©todo | Ruta | DescripciÃ³n |
|--------|------|-------------|
| GET | /admin/status | Estado del servicio admin |
| POST | /admin/user/ban | Banea un usuario |

## Diagrama (Mermaid)
```mermaid
graph TD
    Client --> AdminBFF
    AdminBFF -->|GET| _admin_status[/admin/status]
    AdminBFF -->|POST| _admin_user_ban[/admin/user/ban]
```
