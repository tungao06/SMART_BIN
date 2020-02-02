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
        public ActionResult<SmartBin> GetSmartBin() {
            var list = _smartbinService.GetSmartBin();
            return Ok(list);
        }

        [HttpGet("{ids}", Name = "GetSmartBinByIds")]
        public ActionResult<SmartBin> GetSmartBinByIds(string ids)
        {
            var smartbin = _smartbinService.GetAsync(ids);

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
            var list = _smartbinService.Create(smartbin);

            return Ok(list.Result);
        }

        //api/SmartBin/{Ids}
        [HttpPut("{ids}")]
        public ActionResult<SmartBin> UpdateSmartBin(string ids, SmartBin smartbin)
        {
            var user = _smartbinService.GetAsync(ids);

            if (user == null)
            {
                return NotFound();
            }

            smartbin.Ids = user.Result[0].Object.Ids;
            _smartbinService.UpdateAsync(user.Result[0].Key, smartbin);
            
            return Ok(smartbin);
        }

        [HttpDelete("{ids}")]
        public ActionResult<SmartBin> Delete(string ids)
        {
            _smartbinService.Remove(ids);

            return Ok(ids);
        }
    }
}