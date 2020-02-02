using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using SMART_BIN.Model;
using System.Reactive.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SMART_BIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinController : Controller
    {
        //public BinController(BinServices binService)
        //{
        //    _binService = binService;
        //}

        //api/Bin
        [HttpGet]
        public ActionResult<Bin> GetBinAsync()
        {
            //IFirebaseConfig config = new FirebaseConfig
            //{
            //    AuthSecret = "rOu2qW7xwYDz9jD7RCAHqnpFfyYdVTuTHQcJ0TXL",
            //    BasePath = "https://smartbin-95f7a.firebaseio.com/"
            //};

            //IFirebaseClient client = new FirebaseClient(config);
            //FirebaseResponse response = await client.GetAsync("bin");
            //Bin todo = response.ResultAs<Bin>();

            //return todo;

            var auth = "rOu2qW7xwYDz9jD7RCAHqnpFfyYdVTuTHQcJ0TXL"; // your app secret
            var firebaseClient = new FirebaseClient(
              "https://smartbin-95f7a.firebaseio.com/",
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(auth)
              });

            var dinos = firebaseClient
                      .Child("bin")
                      .OnceAsync<Bin>();

            return Ok(dinos.Result);
        }

        //api/Bin
        [HttpPost]
        public Task<FirebaseObject<Bin>> CreateBin(Bin bin)
        {
            //IFirebaseConfig config = new FirebaseConfig
            //{
            //    AuthSecret = "rOu2qW7xwYDz9jD7RCAHqnpFfyYdVTuTHQcJ0TXL",
            //    BasePath = "https://smartbin-95f7a.firebaseio.com/"
            //};

            //IFirebaseClient client = new FirebaseClient(config);

            var auth = "rOu2qW7xwYDz9jD7RCAHqnpFfyYdVTuTHQcJ0TXL"; // your app secret
            var firebaseClient = new FirebaseClient(
              "https://smartbin-95f7a.firebaseio.com/",
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(auth)
              });

            var dino = firebaseClient
                           .Child("bin")
                           .PostAsync(bin);

            return dino;
        }
    }
}