using Microsoft.AspNetCore.Mvc;
using SMART_BIN.Model;
using SMART_BIN.Services;
using System.Collections.Generic;

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

        //api/Staff/{Uid}
        [HttpPut("{Uid}")]
        public ActionResult<Staff> UpdateStaff(string Uid, Staff staffIn)
        {
            var staff = _staffService.Get(Uid);

            if (staff == null)
            {
                return NotFound();
            }

            staffIn.Id = staff.Id;
            _staffService.Update(Uid, staffIn);

            return Ok(staffIn);
        }
    }
}