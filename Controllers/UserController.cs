using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SMART_BIN.Model;
using SMART_BIN.Services;

namespace SMART_BIN.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller

    {
        private readonly UserServices _staffService;

        public UserController(UserServices staffService)
        {
            _staffService = staffService;
        }

        //api/Staff
        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _staffService.Get();
    }
}