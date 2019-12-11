using MongoDB.Driver;
using SMART_BIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Staff Get(string id) =>
            _staff.Find<Staff>(staff => staff.Id == id).FirstOrDefault();

        public Staff Create(Staff staff)
        {
            _staff.InsertOne(staff);
            return staff;
        }

        public void Update(string id, Staff staffIn) =>
            _staff.ReplaceOne(staff => staff.Id == id, staffIn);

        public void Remove(Staff staffIn) =>
            _staff.DeleteOne(staff => staff.Id == staffIn.Id);

        public void Remove(string id) =>
            _staff.DeleteOne(staff => staff.Id == id);
    }
}