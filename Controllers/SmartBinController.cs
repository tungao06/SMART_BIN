using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SMART_BIN.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SMART_BIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartBinController : Controller
    {
        // GET api/SmartBin
        [HttpGet]
        public ActionResult<string> Get()
        {
            var client = new MongoClient("mongodb+srv://TungAo:Chayanun06@smartbin-mecov.gcp.mongodb.net/SmartBin?retryWrites=true&w=majority");

            IMongoDatabase db = client.GetDatabase("SmartBin");
            var dbList = db.ListCollections().ToList();
            var things = db.GetCollection<BsonDocument>("SmartBin");
            var resultDoc = things.Find(new BsonDocument()).ToList();

            return Ok(resultDoc);
        }

        // GET api/SmartBin/GetStaff
        [HttpGet]
        [Route("GetStaff")]
        public ActionResult<string> GetStaff()
        {
            var client = new MongoClient("mongodb+srv://TungAo:Chayanun06@smartbin-mecov.gcp.mongodb.net/SmartBin?retryWrites=true&w=majority");

            IMongoDatabase db = client.GetDatabase("SmartBin");
            var dbList = db.ListCollections().ToList();
            var things = db.GetCollection<BsonDocument>("Staff");
            var resultDoc = things.Find(new BsonDocument()).ToList();

            return Ok(resultDoc);
        }

        // GET api/SmartBin/GetUser
        [HttpGet]
        [Route("GetUser")]
        public ActionResult<string> GetUser()
        {
            var client = new MongoClient("mongodb+srv://TungAo:Chayanun06@smartbin-mecov.gcp.mongodb.net/SmartBin?retryWrites=true&w=majority");

            IMongoDatabase db = client.GetDatabase("SmartBin");
            var dbList = db.ListCollections().ToList();
            var things = db.GetCollection<BsonDocument>("User");
            var resultDoc = things.Find(new BsonDocument()).ToList();

            return Ok(resultDoc);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}