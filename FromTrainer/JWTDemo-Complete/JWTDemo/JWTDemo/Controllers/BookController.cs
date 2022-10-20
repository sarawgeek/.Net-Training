using JWTDemo.Models;
using JWTDemo.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{


    public class BookController : Controller
    {
        IBookRepository _bookrepo;

        public BookController(IBookRepository bookrepo)
        {
            _bookrepo = bookrepo;
        }

        [HttpPost("CreateBook")]
        public IActionResult CreateBook([FromBody]Book book)
        {
            _bookrepo.CreateBook(book);
            return Ok("Book Created");
        }

        [Authorize]
        
        [HttpGet("[action]")]
        public IActionResult GetBooks()
        {
            var allbooks = _bookrepo.AllBooks();
            return Ok(allbooks);
        }

        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook([FromBody] Book book)
        {
            _bookrepo.UpdateBook(book);
            return Ok("Book Updated");
        }



        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int id)
        {
            _bookrepo.DeleteBook(id);
            return Ok("Book Deleted");
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookrepo.BookById(id);
            return Ok(book);
        }

    }
}
