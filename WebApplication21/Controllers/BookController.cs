using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication21.Api.DTOs;
using WebApplication21.Core.Entities;
using WebApplication21.Core.Interfaces;

namespace WebApplication21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IEntityRepository<Book> _bookReepository;
        private readonly IMapper _mapper;

        public BookController(IEntityRepository<Book> bookReepository, IMapper mapper)
        {
            _bookReepository = bookReepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var books = await _bookReepository.GetAll();

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(booksDto);
        }

        [HttpGet("id")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookReepository.Get(id);

            if (book == null) return NotFound($"Not found book with id:{id}");

            var bookDto = _mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> AddBook([FromBody] BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

            _bookReepository.Post(book);

            return Ok(await _bookReepository.SaveChangesAsync());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

            await _bookReepository.UpdateAsync(book);
                
            return Ok();
        }
    }
}
