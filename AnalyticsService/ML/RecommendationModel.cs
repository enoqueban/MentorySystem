using Microsoft.ML;
using Microsoft.ML.Data;

namespace AnalyticsService.ML;

public class RecommendationData
{
    [LoadColumn(0)] public float UserId { get; set; }
    [LoadColumn(1)] public float ItemId { get; set; }
    [LoadColumn(2)] public float Label  { get; set; }
}

public class RecommendationPrediction { public float Score { get; set; } }

public class RecommendationModel
{
    private readonly MLContext _ml = new(seed:0);
    private ITransformer _model;
    private readonly string _path = "MLModels/RecommendationModel.zip";

    public RecommendationModel() =>
        _model = System.IO.File.Exists(_path)
               ? _ml.Model.Load(System.IO.File.OpenRead(_path), out _)
               : Train();

    private ITransformer Train()
    {
        var train = new[]
        {
            new RecommendationData{UserId=1,ItemId=1,Label=5},
            new RecommendationData{UserId=1,ItemId=2,Label=3},
            new RecommendationData{UserId=1,ItemId=3,Label=4},
            new RecommendationData{UserId=2,ItemId=1,Label=4},
            new RecommendationData{UserId=2,ItemId=2,Label=2},
            new RecommendationData{UserId=2,ItemId=3,Label=1}
        };

        var data = _ml.Data.LoadFromEnumerable(train);
        var opts = new Microsoft.ML.Trainers.MatrixFactorizationTrainer.Options
        {
            MatrixColumnIndexColumnName = nameof(RecommendationData.UserId),
            MatrixRowIndexColumnName    = nameof(RecommendationData.ItemId),
            LabelColumnName             = nameof(RecommendationData.Label),
            NumberOfIterations          = 20,
            ApproximationRank           = 10
        };

        var model = _ml.Recommendation().Trainers.MatrixFactorization(opts).Fit(data);
        System.IO.Directory.CreateDirectory("MLModels");
        _ml.Model.Save(model, data.Schema, _path);
        return model;
    }

    public float Predict(float userId, float itemId)
        => _ml.Model
             .CreatePredictionEngine<RecommendationData,RecommendationPrediction>(_model)
             .Predict(new() {UserId=userId,ItemId=itemId}).Score;
}
