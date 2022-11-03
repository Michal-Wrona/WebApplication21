using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication21.Api.DTOs;
using WebApplication21.Core.Entities;
using WebApplication21.Core.Interfaces;

namespace WebApplication21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<AppRole> roleManager, ITokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username))
                return BadRequest(registerDto.Username + " is taken");

            var user = _mapper.Map<User>(registerDto);

            user.UserName = registerDto.Username.ToLower();

            // userManager save changes in database automatically
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roles = new List<AppRole>
            {
                new AppRole{Name = "User"},
                new AppRole{Name = "Admin"}
            };

            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);
            }

            // if (!await _roleManager.RoleExistsAsync(AppUserRole.Admin))
            //await _roleManager.CreateAsync(new IdentityRole(AppUserRole.Admin));

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
                Id = user.Id,
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
                Id = user.Id,
            };
        }

        [HttpPost("registerAdmin")]
        public async Task<ActionResult<UserDto>> RegisterAdmin(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username))
                return BadRequest(registerDto.Username + " is taken");

            var user = _mapper.Map<User>(registerDto);

            user.UserName = registerDto.Username.ToLower();

            // userManager save changes in database automatically
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roles = new List<AppRole>
            {
                new AppRole{Name = "User"},
                new AppRole{Name = "Admin"}
            };

            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);
            }

                var roleResult = await _userManager.AddToRoleAsync(user, "Admin");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
                Id = user.Id,
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
