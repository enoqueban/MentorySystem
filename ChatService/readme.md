graph TD
    subgraph ChatService
        CS_HUB[ChatHub (SignalR)]
        CS_API[Minimal APIs]
        CS_DB[(MongoDB)]
        CS_DCTX[MongoDbContext]
        CS_MSG[ChatMessage Model]
    end

    CS_HUB --> CS_DB
    CS_API --> CS_DB
    CS_API --> CS_HUB
    CS_DCTX --> CS_DB
