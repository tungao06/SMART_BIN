﻿using MongoDB.Bson;
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
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonIgnoreIfNull]
        public string Ids { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}