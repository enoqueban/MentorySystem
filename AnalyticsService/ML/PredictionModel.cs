namespace AnalyticsService.ML;

public class PredictionModel
{
    public string GetPrediction(string input)
        => $"Predicted insight for '{input}'";
}
