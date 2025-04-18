using Grpc.Core;
using AnalyticsService.Protos;
using AnalyticsService.ML;

namespace AnalyticsService.Services;

public class AnalyticsGrpcService : Analytics.AnalyticsBase
{
    private readonly PredictionModel _pred;

    public AnalyticsGrpcService(PredictionModel pred) => _pred = pred;

    public override Task<AnalyticsResponse> GetInsights(
        AnalyticsRequest request, ServerCallContext context)
    {
        var text = _pred.GetPrediction(request.Query);
        return Task.FromResult(new AnalyticsResponse { Insights = text });
    }
}
