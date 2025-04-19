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

app.MapGet("/admin/status", () => Results.Ok("AdminBFF operational"));
app.MapPost("/admin/user/ban", (string username) =>
{
    return Results.Ok(new
    {
        user = username,
        banned = true,
        timestamp = DateTime.UtcNow
    });
});

app.Run();
