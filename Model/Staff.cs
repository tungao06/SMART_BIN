using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_BIN.Model
{
    public class Staff
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string Ids { get; set; }
        public string Name { get; set; }
    }
}