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
        [HttpGet(Name = "GetStaff")]
        public ActionResult<List<Staff>> GetStaff() =>
            _staffService.Get();

        [HttpGet("{uid}", Name = "GetStaffByUid")]
        public ActionResult<Staff> GetStaffByUid(string uid)
        {
            var staff = _staffService.Get(uid);

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        //api/Staff
        [HttpPost]
        public ActionResult<Staff> CreateStaff(Staff staff)
        {
            _staffService.Create(staff);

            return CreatedAtRoute("GetStaff", new { id = staff.Id.ToString() }, staff);
        }

        //api/Staff/{Ids}
        [HttpPut("{ids}")]
        public ActionResult<Staff> UpdateStaff(string ids, Staff staffIn)
        {
            var staff = _staffService.Get(ids);

            if (staff == null)
            {
                return NotFound();
            }

            staffIn.Id = staff.Id;
            _staffService.Update(ids, staffIn);

            return Ok(staffIn);
        }
    }
}