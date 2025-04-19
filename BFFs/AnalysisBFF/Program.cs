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

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseHttpsRedirection();

app.MapGet("/analysis/status", () => Results.Ok("AnalysisBFF ready"));
app.MapPost("/analysis/report", (string metric) =>
{
    return Results.Ok(new
    {
        metric,
        score = 97.5,
        timestamp = DateTime.UtcNow
    });
});

app.Run();
