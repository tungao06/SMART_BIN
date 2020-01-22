using Microsoft.AspNetCore.Mvc;
using SMART_BIN.Model;
using SMART_BIN.Services;
using System.Collections.Generic;

namespace SMART_BIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinController : Controller
    {
        private readonly BinServices _binService;

        public BinController(BinServices binService)
        {
            _binService = binService;
        }

        //api/Bin
        [HttpGet(Name = "GetBin")]
        public ActionResult<List<Bin>> GetBin() =>
            _binService.Get();

        //api/Bin
    //    [HttpPost]
    //    public ActionResult<Bin> CreateBin(Bin bin)
    //    {
    //        _binService.Create(bin);

    //        return CreatedAtRoute("GetBin", new { id = bin.Id.ToString() }, bin);
    //    }
    }
}