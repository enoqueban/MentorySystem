using ChatService.Configuration;
using ChatService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ChatService.Repositories;

public class MongoChatRepository : IChatRepository
{
    private readonly IMongoCollection<ChatRoom> _rooms;

    public MongoChatRepository(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _rooms = database.GetCollection<ChatRoom>("ChatRooms");
    }

    public async Task<List<ChatRoom>> GetAllRoomsAsync() =>
        await _rooms.Find(_ => true).ToListAsync();

    public async Task<ChatRoom?> GetRoomByIdAsync(string id) =>
        await _rooms.Find(r => r.Id == id).FirstOrDefaultAsync();

    public async Task CreateRoomAsync(ChatRoom room) =>
        await _rooms.InsertOneAsync(room);

    public async Task AddMessageAsync(string roomId, Message message)
    {
        var update = Builders<ChatRoom>.Update.Push(r => r.Messages, message);
        await _rooms.UpdateOneAsync(r => r.Id == roomId, update);
    }
}
