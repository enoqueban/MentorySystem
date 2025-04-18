using EvaluationService.Data;
using EvaluationService.EventSourcing;
using EvaluationService.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddFastEndpoints();
builder.Services.AddDbContext<EventDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add validation
//builder.Services.AddValidatorsFromAssemblyContaining<CreateEvaluationCommandValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining<DeleteEvaluationCommandValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining<GetEvaluationByIdQueryValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining<GetEvaluationsByMentorQueryValidator>();

// Event store
builder.Services.AddSingleton<EventStoreService<EvaluationEvent>>();

// Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseFastEndpoints();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
