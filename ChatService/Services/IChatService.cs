using ChatService.Models;

namespace ChatService.Services;

public interface IChatService
{
    Task<List<ChatRoom>> GetRoomsAsync();
    Task<ChatRoom?> GetRoomAsync(string id);
    Task CreateRoomAsync(string name);
    Task SendMessageAsync(string roomId, string user, string text);
}
