using Core.DTOs.User;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMachine([FromBody] CreateUserDto createUserDto)
        {
            var result = await _userService.CreateUserAsync(createUserDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMachine([FromBody] UpdateUserDto updateUserDto, int id)
        {
            var result = await _userService.UpdateUserAsync(updateUserDto, id);
            return Ok(result);
        }

    }
}
