namespace AnalyticsService.Protos
{
    // Generated code from protobuf - simplified for tests
    public class AnalyticsRequest
    {
        public string Query { get; set; } = string.Empty;
    }

    public class AnalyticsResponse
    {
        public string Insights { get; set; } = string.Empty;
    }

    public class Analytics
    {
        public abstract class AnalyticsBase
        {
            public virtual Task<AnalyticsResponse> GetInsights(AnalyticsRequest request, Grpc.Core.ServerCallContext context)
            {
                return Task.FromResult(new AnalyticsResponse());
            }
        }

        // Add other generated code as needed for tests
        public class PredictionRequest
        {
            public string Input { get; set; } = string.Empty;
        }

        public class PredictionResponse
        {
            public float Score { get; set; }
        }

        public class RecommendationRequest
        {
            public string UserId { get; set; } = string.Empty;
        }

        public class RecommendationResponse
        {
            public List<string> Recommendations { get; set; } = new List<string>();
        }
    }
}