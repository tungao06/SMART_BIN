using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SMART_BIN.Model
{
    public class SmartBin
    {

        public string Ids { get; set; } = "";
        public string Location { get; set; } = "";
        public string Status { get; set; } = "";
    }
}