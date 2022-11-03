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
        private IEntityRepository<Book> _bookReepository;

        public BookController(IEntityRepository<Book> bookReepository)
        {
            _bookReepository = bookReepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            return Ok(await _bookReepository.GetAll());
        }

        [HttpGet("id")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return Ok(await _bookReepository.Get(id));
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            _bookReepository.Post(book);

            return Ok(await _bookReepository.SaveChangesAsync());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(Book book)
        {
             _bookReepository.UpdateAsync(book);
                
            return Ok();

           // return BadRequest();
        }
    }
}
