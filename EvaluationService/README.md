# EvaluationService

Servicio responsable de registrar eventos de evaluación entre usuarios, utilizando un enfoque simplificado de Event Sourcing.

## Funcionalidad

- Almacena eventos relacionados a evaluaciones entre mentores y mentees
- Permite obtener todos los eventos históricos de un evaluado

## Endpoints

- `POST /api/evaluations`: Registra un nuevo evento
- `GET /api/evaluations/{evaluateeId}`: Devuelve los eventos históricos para un evaluado

## Tecnologías

- .NET 8
- Mínimas dependencias (sin base de datos persistente, simulado en memoria)

graph TD
    subgraph EvaluationService
        ES_MODULE[CarterModule]
        ES_STORE[EventStoreService (In-Memory)]
        ES_EVENT[EvaluationEvent]
    end

    ES_MODULE --> ES_STORE
    ES_STORE --> ES_EVENT
