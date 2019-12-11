using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SMART_BIN.Model;
using SMART_BIN.Services;

namespace SMART_BIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller

    {
        private readonly StaffServices _staffService;

        public StaffController(StaffServices staffService)
        {
            _staffService = staffService;
        }

        //api/Staff
        [HttpGet]
        public ActionResult<List<Staff>> Get() =>
            _staffService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStaff")]
        public ActionResult<Staff> Get(string id)
        {
            var staff = _staffService.Get(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        //api/Staff
        [HttpPost]
        public ActionResult<Staff> Create(Staff staff)
        {
            _staffService.Create(staff);

            return CreatedAtRoute("GetStaff", new { id = staff.Id.ToString() }, staff);
        }

        //api/Staff
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Staff staffIn)
        {
            var staff = _staffService.Get(id);

            if (staff == null)
            {
                return NotFound();
            }

            _staffService.Update(id, staffIn);

            return NoContent();
        }
    }
}