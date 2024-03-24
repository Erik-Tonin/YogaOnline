using Application.DTOs;
using Application.Implementations;
using FluentValidation.Results;
using YogaOnline.Domain.Entities;

namespace Application.Contracts
{
    public interface IUserService
    {
        Task<ValidationResultDTO<User>> Register(UserDTO userDTO);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<ValidationResult> UpdateUser(UserDTO user);
        Task<UserDTO> GetById(Guid id);
        Task<ValidationResult> Delete(Guid id);
        Task<UserDTO> GetByEmail(string email);
        Task<UserDTO> GetCPF(string cpf);
        Task<ValidationResult> UpdatePassword(Guid Guid, string password, string confirmPassword);
        Task<ValidationResult> ForgotPassword(UserDTO dto);
        Task<ValidationResult> Login(string email, string password);
    }
}
