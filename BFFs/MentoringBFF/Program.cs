var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseHttpsRedirection();

// Endpoints
app.MapGet("/mentoring/status", () => Results.Ok("MentoringBFF is running"));
app.MapPost("/mentoring/session/start", (string mentor, string mentee) =>
{
    return Results.Ok(new { started = true, mentor, mentee, timestamp = DateTime.UtcNow });
});

app.Run();
