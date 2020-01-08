using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SMART_BIN.Model
{
    public class Staff
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonIgnoreIfNull]
        public string Ids { get; set; }

        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string img { get; set; }
        public string Uid { get; set; }
    }
}