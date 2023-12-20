using Bank_DotnetCore.Dtos;
using Bank_DotnetCore.Models;
using Bank_DotnetCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_DotnetCore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<AddUserDto>> AddUser(AddUserDto user)
        {
            var userResponse = await _userService.CreateUser(user);
            if (userResponse == null)
            {
                return BadRequest("User already exists");
            }
            return Ok(user);

        }
        [HttpGet("id")]
        public async Task<ActionResult<GetUserDto>> GetUserDetails(int id)
        {
            var UserDetails = await _userService.GetUserById(id);
            if (UserDetails == null)
            {
                return BadRequest("User was not found.");
            }
            return Ok(UserDetails);

        }
        [HttpPut]
        public async Task<ActionResult<UserModel>> UpdateUser(UserModel user)
        {
            var UserDetails = await _userService.UpdateUser(user);
            if (UserDetails == null)
            {
                return BadRequest("User was not found.");
            }
            return Ok(UserDetails);

        }
    }
}
