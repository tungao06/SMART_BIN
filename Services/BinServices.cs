using MongoDB.Driver;
using SMART_BIN.Model;
using System.Collections.Generic;
using System.Linq;

namespace SMART_BIN.Services
{
    public class BinServices
    {
        private readonly IMongoCollection<Bin> _bin;

        public BinServices(ISmartBinDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bin = database.GetCollection<Bin>("Bin");
        }

        public List<Bin> Get() =>
            _bin.Find(bin => true).ToList();

        public Bin Get(string id) =>
            _bin.Find<Bin>(bin => bin.Id == id).FirstOrDefault();

        public Bin Create(Bin bin)
        {
            _bin.InsertOne(bin);
            return bin;
        }

        public void Update(string id, Bin binIn) =>
            _bin.ReplaceOne(bin => bin.Id == id, binIn);

        public void Remove(Bin binIn) =>
            _bin.DeleteOne(bin => bin.Id == binIn.Id);

        public void Remove(string id) =>
            _bin.DeleteOne(bin => bin.Id == id);
    }
}