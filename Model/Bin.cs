using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SMART_BIN.Model
{
    public class Bin
    {
        public long GoodBin { get; set; } = 0;
        public long BadBin { get; set; } = 0;
    }
}