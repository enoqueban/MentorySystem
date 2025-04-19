using AnalyticsService.ML;
using AnalyticsService.Protos;
using Grpc.Core;

namespace AnalyticsService.Services
{
    public class AnalyticsGrpcService : Analytics.AnalyticsBase
    {
        private readonly PredictionModel _predictionModel;
        private readonly RecommendationModel _recommendationModel;

        public AnalyticsGrpcService(PredictionModel predictionModel, RecommendationModel recommendationModel)
        {
            _predictionModel = predictionModel;
            _recommendationModel = recommendationModel;
        }

        public override Task<AnalyticsResponse> GetInsights(AnalyticsRequest request, ServerCallContext context)
        {
            var insights = _predictionModel.GetPrediction(request.Query);
            return Task.FromResult(new AnalyticsResponse { Insights = insights });
        }
    }
}