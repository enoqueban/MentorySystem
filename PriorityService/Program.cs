using FastEndpoints;
using FastEndpoints.Swagger; // <-- 💡 NECESARIO
using PriorityService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddScoped<DapperRepository>();

// Solo con esto Swagger funciona
builder.Services.SwaggerDocument(); // <-- ✔️ FastEndpoints lo usa así

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5002); // Puerto personalizado
});

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen(); // <-- ✔️ de FastEndpoints

app.Run();
