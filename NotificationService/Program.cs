using NotificationService.Services;
using NotificationService.Data;
using MentoringSystem.Shared.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddSingleton<RabbitMQService>();
builder.Services.AddSingleton<RedisCache>();
builder.Services.AddSingleton<NotificationProcessor>();

var app = builder.Build();

app.UseHttpsRedirection();

var processor = app.Services.GetRequiredService<NotificationProcessor>();
//processor.StartProcessing();

app.MapGet("/", () => "Notification Service is running.");

app.Run();
