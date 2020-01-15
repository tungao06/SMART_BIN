using MongoDB.Driver;
using SMART_BIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_BIN.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<User> _user;

        public UserServices(ISmartBinDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>("User");
        }

        public List<User> Get() =>
            _user.Find(user => true).ToList();

        public User Get(string uid) =>
            _user.Find<User>(user => user.Uid == uid).FirstOrDefault();

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(string Uid, User userIn) =>
            _user.ReplaceOne(user => user.Uid == Uid, userIn);

        public void Remove(User userIn) =>
            _user.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _user.DeleteOne(user => user.Id == id);
    }
}