using Firebase.Database;
using Firebase.Database.Query;
using MongoDB.Driver;
using SMART_BIN.Model;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_BIN.Services
{
    public class SmartBinServices
    {
        private readonly IMongoCollection<SmartBin> _smartbin;
        private readonly FirebaseClient firebaseClient;

        public SmartBinServices(ISmartBinDatabaseSettings settings)
        {
            //var client = new MongoClient(settings.ConnectionString);
            //var database = client.GetDatabase(settings.DatabaseName);

            var auth = "rOu2qW7xwYDz9jD7RCAHqnpFfyYdVTuTHQcJ0TXL"; // your app secret
            firebaseClient = new FirebaseClient(
             "https://smartbin-95f7a.firebaseio.com/",
             new FirebaseOptions
             {
                 AuthTokenAsyncFactory = () => Task.FromResult(auth)
             });

            //_smartbin = database.GetCollection<SmartBin>("SmartBin");
        }

        public dynamic GetSmartBin()
        {
            var dinos = firebaseClient
                          .Child("smartbin")
                          .OnceAsync<SmartBin>();

            return dinos.Result;
        }

        public async Task<dynamic> GetAsync(string ids)
        {
            //_smartbin.Find<SmartBin>(smartbin => smartbin.Ids == ids).FirstOrDefault();
            var dinos = await firebaseClient
                          .Child("smartbin")
                          .OrderBy("Ids")
                          .EqualTo(ids)
                          .OnceAsync<SmartBin>();
            
            return dinos;
        }

        public Task<FirebaseObject<SmartBin>> Create(SmartBin smartbin)
        {
            var dino = firebaseClient
                           .Child("smartbin")
                           .PostAsync(smartbin);
            return dino;
        }

        public async Task UpdateAsync(string ids, SmartBin smartbinIn)
        {
            await firebaseClient
                  .Child("smartbin")
                  .Child(ids)
                  .PutAsync(smartbinIn);
        }

        public void Remove(SmartBin smartbinIn) =>
            _smartbin.DeleteOne(smartbin => smartbin.Ids == smartbinIn.Ids);

        public async Task Remove(string ids)
        {
           var dinos =  GetAsync(ids);

            await firebaseClient
                  .Child("smartbin")
                  .Child($"{dinos.Result[0].Key}")
                  .DeleteAsync();
        }
    }
}