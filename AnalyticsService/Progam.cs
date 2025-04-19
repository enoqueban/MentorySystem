using AnalyticsService.ML;
using AnalyticsService.Services;

var builder = WebApplication.CreateBuilder(args);

// gRPC + ML singletons
builder.Services.AddGrpc();
builder.Services.AddSingleton<PredictionModel>();
builder.Services.AddSingleton<RecommendationModel>();

var app = builder.Build();
app.Urls.Clear();
app.Urls.Add("http://localhost:5005");
app.Urls.Add("https://localhost:5055");
app.MapGrpcService<AnalyticsGrpcService>();
app.MapGet("/", () => "Analytics Service is running.");

// Minimal-API: score de recomendación
app.MapGet("/recommendation",
    (RecommendationModel ml, float userId, float itemId)
        => Results.Ok(new { userId, itemId, score = ml.Predict(userId, itemId) }));

app.Run();