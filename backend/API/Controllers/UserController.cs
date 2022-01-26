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
        public async Task<JsonResult> Add(CreateUserDto createUserDto)
        {
            var result = await _userService.AddAsync(createUserDto);
            return Json(result);
        }
    }
}
