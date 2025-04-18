using ChatService.Models;

namespace ChatService.Repositories;

public interface IChatRepository
{
    Task<List<ChatRoom>> GetAllRoomsAsync();
    Task<ChatRoom?> GetRoomByIdAsync(string id);
    Task CreateRoomAsync(ChatRoom room);
    Task AddMessageAsync(string roomId, Message message);
}
