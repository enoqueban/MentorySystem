# NotificationsBFF
Manejo de notificaciones del sistema.
## Endpoints
| MÃ©todo | Ruta | DescripciÃ³n |
|--------|------|-------------|
| GET | /notifications/status | Estado del servicio |
| POST | /notifications/send | EnvÃ­a una notificaciÃ³n |

## Diagrama (Mermaid)
```mermaid
graph TD
    Client --> NotificationsBFF
    NotificationsBFF -->|GET| _notifications_status[/notifications/status]
    NotificationsBFF -->|POST| _notifications_send[/notifications/send]
```
