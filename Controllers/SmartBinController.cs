using Microsoft.AspNetCore.Mvc;
using SMART_BIN.Model;
using SMART_BIN.Services;
using System.Collections.Generic;

namespace SMART_BIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartBinController : Controller
    {
        private readonly SmartBinServices _smartbinService;

        public SmartBinController(SmartBinServices smartbinService)
        {
            _smartbinService = smartbinService;
        }
        //api/SmartBin
        [HttpGet(Name = "GetSmartBin")]
        public ActionResult<List<SmartBin>> GetSmartBin() =>
            _smartbinService.Get();

        [HttpGet("{uid}", Name = "GetSmartBinByUid")]
        public ActionResult<SmartBin> GetSmartBinByUid(string uid)
        {
            var smartbin = _smartbinService.Get(uid);

            if (smartbin == null)
            {
                return NotFound();
            }

            return Ok(smartbin);
        }

        //api/SmartBin
        [HttpPost]
        public ActionResult<SmartBin> CreateSmartBin(SmartBin smartbin)
        {
            _smartbinService.Create(smartbin);

            return CreatedAtRoute("GetSmartBin", new { id = smartbin.Id.ToString() }, smartbin);
        }

        //api/SmartBin/{Ids}
        [HttpPut("{ids}")]
        public ActionResult<SmartBin> UpdateSmartBin(string ids, SmartBin smartbin)
        {
            var user = _smartbinService.Get(ids);

            if (user == null)
            {
                return NotFound();
            }

            smartbin.Ids = user.Ids;
            _smartbinService.Update(ids, smartbin);

            return Ok(smartbin);
        }

        [HttpDelete("{ids}")]
        public ActionResult<SmartBin> Delete(string ids)
        {
            _smartbinService.Remove(ids);

            return Ok();
        }
    }
}