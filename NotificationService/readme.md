graph TD
    subgraph NotificationService
        NS_PROC[NotificationProcessor]
        NS_REDIS[(Redis Cache)]
        NS_RMQ[RabbitMQService]
        NS_PUB[PublishNotification()]
        NS_SUB[StartProcessing()]
    end

    NS_PROC --> NS_RMQ
    NS_PROC --> NS_REDIS
    NS_SUB --> NS_RMQ
    NS_PUB --> NS_RMQ
