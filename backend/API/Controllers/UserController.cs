using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Utilities.Results.Concrete;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<JsonResult> Add(CreateUserDto createUserDto)
        {
            var result = await _userService.AddAsync(createUserDto);
            return Json(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateToken(loginDto);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest(Messages.User.NonUser());
            }
            return BadRequest(loginDto);
        }

        [Authorize]
        [HttpGet("deneme")]
        public IActionResult Add()
        {
            return Ok();
        }


    }
}
