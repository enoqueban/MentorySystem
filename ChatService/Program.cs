using ChatService.Repositories;
using ChatService.Services;
using ChatService.Configuration;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using ChatService.Hubs;
var builder = WebApplication.CreateBuilder(args);

// MongoDB settings
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// Add SignalR
builder.Services.AddSignalR();

builder.Services.AddScoped<IChatRepository, MongoChatRepository>();
builder.Services.AddScoped<IChatService, ChatService.Services.ChatService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5001); // Puerto libre
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapHub<ChatHub>("/hub/chat");
app.MapGet("/api/chat/rooms", async (IChatService chatService) =>
{
    var rooms = await chatService.GetRoomsAsync();
    return Results.Ok(rooms);
});

app.MapGet("/api/chat/rooms/{id}", async (string id, IChatService chatService) =>
{
    var room = await chatService.GetRoomAsync(id);
    return room is not null ? Results.Ok(room) : Results.NotFound();
});

app.MapPost("/api/chat/rooms", async (string name, IChatService chatService) =>
{
    await chatService.CreateRoomAsync(name);
    return Results.Created($"/api/chat/rooms", new { name });
});

app.MapPost("/api/chat/rooms/{id}/messages", async (string id, string user, string text, IChatService chatService) =>
{
    await chatService.SendMessageAsync(id, user, text);
    return Results.Ok();
});

app.Run();