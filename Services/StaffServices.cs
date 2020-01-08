using MongoDB.Driver;
using SMART_BIN.Model;
using System.Collections.Generic;
using System.Linq;

namespace SMART_BIN.Services
{
    public class StaffServices
    {
        private readonly IMongoCollection<Staff> _staff;

        public StaffServices(ISmartBinDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _staff = database.GetCollection<Staff>("Staff");
        }

        public List<Staff> Get() =>
            _staff.Find(smartbin => true).ToList();

        public Staff Get(string uid) =>
            _staff.Find<Staff>(staff => staff.Uid == uid).FirstOrDefault();

        public Staff Create(Staff staff)
        {
            _staff.InsertOne(staff);
            return staff;
        }

        public void Update(string Uid, Staff staffIn) =>
            _staff.ReplaceOne(staff => staff.Uid == Uid, staffIn);

        public void Remove(Staff staffIn) =>
            _staff.DeleteOne(staff => staff.Id == staffIn.Id);

        public void Remove(string id) =>
            _staff.DeleteOne(staff => staff.Id == id);
    }
}