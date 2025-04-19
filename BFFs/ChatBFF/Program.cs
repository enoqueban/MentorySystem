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
app.MapGet("/chat/status", () => Results.Ok("ChatBFF is online."));
app.MapPost("/chat/send", (string user, string message) =>
{
    return Results.Ok(new
    {
        status = "delivered",
        user,
        message,
        timestamp = DateTime.UtcNow
    });
});

await app.RunAsync();
