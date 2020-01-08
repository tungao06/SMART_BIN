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

        //api/Staff
        [HttpGet(Name = "GetUser")]
        public ActionResult<List<User>> GetUser() =>
            _userService.Get();

        [HttpGet("{ids}", Name = "GetUserByIds")]
        public ActionResult<User> GetUserByIds(string ids)
        {
            var user = _userService.Get(ids);

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

            return CreatedAtRoute("Get", new { id = user.Id.ToString() }, user);
        }

        //api/Staff/{Ids}
        [HttpPut("{ids}")]
        public ActionResult<User> UpdateUser(string ids, User userIn)
        {
            var user = _userService.Get(ids);

            if (user == null)
            {
                return NotFound();
            }

            userIn.Id = user.Id;
            _userService.Update(ids, userIn);

            return Ok(userIn);
        }
    }
}