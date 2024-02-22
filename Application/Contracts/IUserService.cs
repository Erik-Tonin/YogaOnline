using Application.DTOs;
using FluentValidation.Results;
using YogaOnline.Domain.Entities;

namespace Application.Contracts
{
    public interface IUserService
    {
        Task<User> Register(User userDTO);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<ValidationResult> UpdateUser(UserDTO user);
        Task<UserDTO> GetById(int id);
        Task<ValidationResult> Delete(int id);
        Task<UserDTO> GetByEmail(string email);
        Task<UserDTO> GetCPF(string cpf);
        Task<ValidationResult> UpdatePassword(int id, string password, string confirmPassword);
        Task<ValidationResult> ForgotPassword(UserDTO dto);
        Task<ValidationResult> Login(string email, string password);
    }
}
