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
app.MapGet("/auth/status", () => Results.Ok("AuthenticationBFF is up and running."));
app.MapPost("/auth/login", (string user, string pass) =>
{
    if (user == "admin" && pass == "123")
        return Results.Ok(new { token = "fake-jwt-token", role = "admin" });
    return Results.Unauthorized();
});

await app.RunAsync();