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

app.MapGet("/notifications/status", () => Results.Ok("NotificationsBFF running"));
app.MapPost("/notifications/send", (string to, string content) =>
{
    return Results.Ok(new
    {
        to,
        content,
        sent = true,
        timestamp = DateTime.UtcNow
    });
});

app.Run();
