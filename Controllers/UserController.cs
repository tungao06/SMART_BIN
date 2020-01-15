using Microsoft.AspNetCore.Mvc;
using SMART_BIN.Model;
using SMART_BIN.Services;
using System.Collections.Generic;

namespace SMART_BIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserServices _userService;

        public UserController(UserServices userService)
        {
            _userService = userService;
        }

        //api/User
        [HttpGet(Name = "GetUser")]
        public ActionResult<List<User>> GetUser() =>
            _userService.Get();

        [HttpGet("{uid}", Name = "GetUserByIds")]
        public ActionResult<User> GetUserByIds(string uid)
        {
            var user = _userService.Get(uid);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //api/User
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        //api/Staff/{Uid}
        [HttpPut("{Uid}")]
        public ActionResult<User> UpdateUser(string Uid, User userIn)
        {
            var user = _userService.Get(Uid);

            if (user == null)
            {
                return NotFound();
            }

            userIn.Id = user.Id;
            _userService.Update(Uid, userIn);

            return Ok(userIn);
        }
    }
}