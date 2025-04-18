using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChatService.Models;

public class Message
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("User")]
    public string User { get; set; } = string.Empty;

    [BsonElement("Text")]
    public string Text { get; set; } = string.Empty;

    [BsonElement("Timestamp")]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
