# MentoringBFF
Maneja sesiones de mentorÃ­a entre usuarios.
## Endpoints
| MÃ©todo | Ruta | DescripciÃ³n |
|--------|------|-------------|
| GET | /mentoring/status | Estado del servicio de mentorÃ­a |
| POST | /mentoring/session/start | Inicia una sesiÃ³n de mentorÃ­a |

## Diagrama (Mermaid)
```mermaid
graph TD
    Client --> MentoringBFF
    MentoringBFF -->|GET| _mentoring_status[/mentoring/status]
    MentoringBFF -->|POST| _mentoring_session_start[/mentoring/session/start]
```
