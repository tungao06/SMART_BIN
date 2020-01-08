using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SMART_BIN.Model
{
    public class SmartBin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Ids { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}