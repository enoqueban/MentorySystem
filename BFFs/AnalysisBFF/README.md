# AnalysisBFF
Expone mÃ©tricas e informes de anÃ¡lisis.
## Endpoints
| MÃ©todo | Ruta | DescripciÃ³n |
|--------|------|-------------|
| GET | /analysis/status | Estado del anÃ¡lisis |
| POST | /analysis/report | Genera reporte de mÃ©trica |

## Diagrama (Mermaid)
```mermaid
graph TD
    Client --> AnalysisBFF
    AnalysisBFF -->|GET| _analysis_status[/analysis/status]
    AnalysisBFF -->|POST| _analysis_report[/analysis/report]
```
