using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication21.Core.Entities;
using WebApplication21.Core.Interfaces;

namespace WebApplication21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReservationController : ControllerBase
    {
        private IBookRepository<BookReservation> _bookReepository;

        public BookReservationController(IBookRepository<BookReservation> bookReepository)
        {
            _bookReepository = bookReepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReservation>>> GetAll()
        {
            return Ok(await _bookReepository.GetAll());
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProduct([FromBody] BookReservation bookReservation)
        {
            _bookReepository.Post(bookReservation);

            return Ok(await _bookReepository.SaveChangesAsync());
        }
    }
}
