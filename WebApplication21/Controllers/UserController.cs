using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication21.Core.Entities;
using WebApplication21.Core.Interfaces;

namespace WebApplication21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBookRepository<User> _bookReepository;

        public UserController(IBookRepository<User> bookReepository)
        {
            _bookReepository = bookReepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok(await _bookReepository.GetAll());
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProduct([FromBody] User user)
        {
            _bookReepository.Post(user);

            return Ok(await _bookReepository.SaveChangesAsync());
        }
    }
}
