graph TD
    subgraph AnalyticsService
        AS_GRPC[gRPC Endpoint]
        AS_ML[PredictionModel (ML.NET)]
        AS_ES[(Elasticsearch)]
        AS_PROTO[analytics.proto]
    end

    AS_GRPC --> AS_ML
    AS_ML --> AS_ES
    AS_GRPC --> AS_PROTO
