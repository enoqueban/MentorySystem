using FeedbackService.Data;
using FeedbackService.EventSourcing;
using FeedbackService.Models;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Servicios principales
builder.Services.AddFastEndpoints();
builder.Services.AddDbContext<FeedbackDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// EventStore en memoria para simplificar
builder.Services.AddSingleton<EventStoreService<FeedbackEvent>>();

// Swagger con FastEndpoints
builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "FeedbackService API";
        s.Version = "v1";
        s.Description = "Microservicio para gestión de feedbacks.";
    };
});

// Validadores FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Cambia el puerto si otros servicios usan el 5000
builder.WebHost.ConfigureKestrel(opt =>
{
    opt.ListenAnyIP(5004); // Puerto para FeedbackService
});

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen(); // habilita Swagger en /swagger

app.Run();
