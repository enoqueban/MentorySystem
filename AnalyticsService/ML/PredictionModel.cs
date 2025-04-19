namespace AnalyticsService.ML;

public class PredictionModel
{
    public virtual string GetPrediction(string input)
        => $"Predicted insight for '{input}'";
}