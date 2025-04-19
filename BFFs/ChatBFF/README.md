# ChatBFF
Orquesta el envÃ­o de mensajes entre usuarios.
## Endpoints
| MÃ©todo | Ruta | DescripciÃ³n |
|--------|------|-------------|
| GET | /chat/status | Estado del chat |
| POST | /chat/send | Envia un mensaje de chat |

## Diagrama (Mermaid)
```mermaid
graph TD
    Client --> ChatBFF
    ChatBFF -->|GET| _chat_status[/chat/status]
    ChatBFF -->|POST| _chat_send[/chat/send]
```
