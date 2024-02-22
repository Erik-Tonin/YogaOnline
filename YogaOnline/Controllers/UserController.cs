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
        [HttpPost("Register")]
        public async Task<User> Register(User userDTO)
        {
            User user = await _userService.Register(userDTO);

            return user;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return await _userService.GetAll();
        }

        [AllowAnonymous]
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            return CustomResponse(await _userService.UpdateUser(user));
        }

        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<UserDTO> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        [AllowAnonymous]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return CustomResponse(await _userService.Delete(id));
        }

        [AllowAnonymous]
        [HttpGet("GetByEmail")]
        public async Task<UserDTO> GetByEmail(string email)
        {
            return await _userService.GetByEmail(email);
        }

        [AllowAnonymous]
        [HttpGet("GetCPF")]
        public async Task<UserDTO> GetCPF(string cpf)
        {
            return await _userService.GetCPF(cpf);
        }

        [AllowAnonymous]
        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(int id, string password, string confirmPassword)
        {
            return CustomResponse(await _userService.UpdatePassword(id, password, confirmPassword));
        }

        [AllowAnonymous]
        [HttpPut("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(UserDTO dto)
        {
            return CustomResponse(await _userService.ForgotPassword(dto));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            return CustomResponse(await _userService.Login(email, password));
        }
    }
}
