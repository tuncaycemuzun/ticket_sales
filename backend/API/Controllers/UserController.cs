using Core.Abstract;
using Core.Concrete;
using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Services;
using Shared.Utilities.Results.ComplexTypes;
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

        [HttpPost]
        [Route("login")]
        public async Task<JsonResult> Login(LoginDto loginDto)
        {
            var result = await _userService.CreateToken(loginDto);
            return Json(result);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<JsonResult> RefreshToken([FromBody]RefreshToken refreshToken)
        {
            var result = await _userService.CreateTokenByRefreshToken(refreshToken.Token);
            return Json(result);
        }


    }
}
