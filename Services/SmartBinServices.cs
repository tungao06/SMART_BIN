using MongoDB.Bson;
using MongoDB.Driver;
using SMART_BIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_BIN.Services
{
    public class SmartBinServices
    {
        private readonly IMongoCollection<SmartBin> _smartbin;

        public SmartBinServices(ISmartBinDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _smartbin = database.GetCollection<SmartBin>("SmartBin");
        }

        public List<SmartBin> Get() =>
            _smartbin.Find(smartbin => true).ToList();

        public SmartBin Get(string id) =>
            _smartbin.Find<SmartBin>(smartbin => smartbin.Id == id).FirstOrDefault();

        public SmartBin Create(SmartBin book)
        {
            _smartbin.InsertOne(book);
            return book;
        }

        public void Update(string id, SmartBin smartbinIn) =>
            _smartbin.ReplaceOne(smartbin => smartbin.Id == id, smartbinIn);

        public void Remove(SmartBin smartbinIn) =>
            _smartbin.DeleteOne(smartbin => smartbin.Id == smartbinIn.Id);

        public void Remove(string id) =>
            _smartbin.DeleteOne(smartbin => smartbin.Id == id);
    }
}