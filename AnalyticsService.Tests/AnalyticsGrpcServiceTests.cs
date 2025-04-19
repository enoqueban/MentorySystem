using AnalyticsService.ML;
using AnalyticsService.Protos;
using AnalyticsService.Services;
using FluentAssertions;
using Grpc.Core;
using Moq;
using Xunit;

namespace AnalyticsService.Tests
{
    public class AnalyticsGrpcServiceTests
    {
        private readonly AnalyticsGrpcService _service;

        public AnalyticsGrpcServiceTests()
        {
            // Create test models without ML.NET dependencies
            var predictionModel = new TestPredictionModel();
            var recommendationModel = new TestRecommendationModel();
            
            _service = new AnalyticsGrpcService(predictionModel, recommendationModel);
        }

        [Fact]
        public async Task GetInsights_ShouldReturnPrediction()
        {
            // Arrange
            var request = new AnalyticsRequest { Query = "test-query" };
            
            // Create a simple mock ServerCallContext instead
            var mockContext = new Mock<ServerCallContext>();
            var context = mockContext.Object;

            // Act
            var result = await _service.GetInsights(request, context);

            // Assert
            result.Should().NotBeNull();
            result.Insights.Should().NotBeNullOrEmpty();
            result.Insights.Should().Contain("test-query");
        }
    }

    // Test implementation of PredictionModel to avoid ML.NET issues
    public class TestPredictionModel : PredictionModel
    {
        public override string GetPrediction(string input)
        {
            return $"Test prediction for '{input}'";
        }
    }

    // Test implementation of RecommendationModel to avoid ML.NET issues
    public class TestRecommendationModel : RecommendationModel
    {
        public TestRecommendationModel() : base(true) { }
        
        public override float Predict(float userId, float itemId)
        {
            return 0.75f;
        }
    }
}