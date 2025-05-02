using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AnketSistemi.Models;

public class Soru
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("metin")]
    public string Metin { get; set; }
}