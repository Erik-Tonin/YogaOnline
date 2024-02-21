using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaOnline.Domain.Entities;

namespace YogaOnline.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("NewUser")]
        public async Task<IActionResult> NewUser(UserDTO userDTO)
        {
            return CustomResponse(await _userService.NewUser(userDTO));
        }

        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<User> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        [AllowAnonymous]
        [HttpPut("changeUser")]
        public async Task<IActionResult> ChangeUser(int id, UserDTO user)
        {
            return CustomResponse(await _userService.UpdateUser(id, user));
        }

        [AllowAnonymous]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return CustomResponse(await _userService.DeleteUser(id));
        }
    }
}
