using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication21.Api.DTOs;
using WebApplication21.Core.Entities;
using WebApplication21.Core.Interfaces;

namespace WebApplication21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReservationController : ControllerBase
    {
        private readonly IBookReservationRepository _bookReepository;
        private readonly IMapper _mapper;

        public BookReservationController(IBookReservationRepository bookReepository,
            IMapper mapper)
        {
            _bookReepository = bookReepository;
            _mapper = mapper;
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetAllFromOneBook(int bookId)
        {
            var bookReservation = await _bookReepository.GetAllReservationFromOneBook(bookId);

            var bookReservationDto = _mapper.Map<IEnumerable<BookReservationDto>>(bookReservation);

            return Ok(bookReservationDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetAll()
        {
            var bookReservation = await _bookReepository.GetAll();

            var bookReservationDto = _mapper.Map<IEnumerable<BookReservationDto>>(bookReservation);

            return Ok(bookReservationDto);

        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProduct([FromBody] BookReservationDto bookReservationDto)
        {
            var bookReservation = _mapper.Map<BookReservation>(bookReservationDto);
                
            _bookReepository.Post(bookReservation);

            return Ok(await _bookReepository.SaveChangesAsync());
        }
    }
}
