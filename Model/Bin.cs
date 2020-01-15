using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SMART_BIN.Model
{
    public class Bin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        public string Type { get; set; } = "";
    }
}