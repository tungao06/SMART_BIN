using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SMART_BIN.Model;
using SMART_BIN.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [HttpGet]
        public ActionResult<List<SmartBin>> Get() =>
            _smartbinService.Get();

        //[HttpGet("{id:length(24)}", Name = "GetBook")]
        //public ActionResult<Book> Get(string id)
        //{
        //    var book = _bookService.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return book;
        //}

        //[HttpPost]
        //public ActionResult<Book> Create(Book book)
        //{
        //    _bookService.Create(book);

        //    return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        //}

        //[HttpPut("{id:length(24)}")]
        //public IActionResult Update(string id, Book bookIn)
        //{
        //    var book = _bookService.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _bookService.Update(id, bookIn);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public IActionResult Delete(string id)
        //{
        //    var book = _bookService.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _bookService.Remove(book.Id);

        //    return NoContent();
        //}
    }
}