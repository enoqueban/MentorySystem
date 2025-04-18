graph TD
    subgraph PriorityService
        PS_API[FastEndpoints]
        PS_CQRS[Commands / Queries]
        PS_HANDLERS[Handlers]
        PS_DB[(PostgreSQL via Dapper)]
        PS_REPO[DapperRepository]
    end

    PS_API --> PS_CQRS
    PS_CQRS --> PS_HANDLERS
    PS_HANDLERS --> PS_REPO
    PS_REPO --> PS_DB
