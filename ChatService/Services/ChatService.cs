using ChatService.Models;
using ChatService.Repositories;

namespace ChatService.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _repo;

    public ChatService(IChatRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<ChatRoom>> GetRoomsAsync() =>
        await _repo.GetAllRoomsAsync();

    public async Task<ChatRoom?> GetRoomAsync(string id) =>
        await _repo.GetRoomByIdAsync(id);

    public async Task CreateRoomAsync(string name)
    {
        var room = new ChatRoom { Name = name };
        await _repo.CreateRoomAsync(room);
    }

    public async Task SendMessageAsync(string roomId, string user, string text)
    {
        var msg = new Message
        {
            User = user,
            Text = text,
            Timestamp = DateTime.UtcNow
        };
        await _repo.AddMessageAsync(roomId, msg);
    }
}
