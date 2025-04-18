graph TD
    subgraph Frontend
        FE[Frontend ReactApp]
    end

    subgraph BFFs
        BFF_Auth[AuthenticationBFF]
        BFF_Mentor[MentoringBFF]
        BFF_Chat[ChatBFF]
        BFF_Analytics[AnalysisBFF]
        BFF_Notif[NotificationsBFF]
        BFF_Admin[AdminBFF]
    end

    subgraph Microservicios
        IS[IdentityService<br/>🧩 JWT + mTLS<br/>🗄️ SQL Server<br/>🔐 OAuth2.0]
        PS[PriorityService<br/>🧩 CQRS + FastEndpoints<br/>🗄️ PostgreSQL<br/>🔗 REST]
        ES[EvaluationService<br/>🧩 Event Sourcing<br/>🗄️ En Memoria<br/>🔗 REST]
        CS[ChatService<br/>🧩 SignalR<br/>🗄️ MongoDB<br/>🔌 WebSocket + REST]
        AS[AnalyticsService<br/>🧩 gRPC + ML.NET<br/>🗄️ Elasticsearch<br/>🔗 gRPC]
        NS[NotificationService<br/>🧩 Async Events<br/>🗄️ Redis<br/>📬 RabbitMQ]
    end

    FE --> BFF_Auth --> IS
    FE --> BFF_Mentor --> IS
    BFF_Mentor --> PS
    BFF_Mentor --> ES
    FE --> BFF_Chat --> CS
    FE --> BFF_Analytics --> AS
    FE --> BFF_Notif --> NS
    FE --> BFF_Admin --> IS
