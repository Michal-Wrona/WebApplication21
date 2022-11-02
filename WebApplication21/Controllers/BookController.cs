using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication21.Core.Entities;
using WebApplication21.Core.Interfaces;

namespace WebApplication21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository<Book> _bookReepository;

        public BookController(IBookRepository<Book> bookReepository)
        {
            _bookReepository = bookReepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            return Ok(await _bookReepository.GetAll());
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProduct([FromBody] Book book)
        {
            _bookReepository.Post(book);

            return Ok(await _bookReepository.SaveChangesAsync());
        }
    }
}
