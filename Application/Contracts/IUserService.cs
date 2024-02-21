using Application.DTOs;
using FluentValidation.Results;
using YogaOnline.Domain.Entities;

namespace Application.Contracts
{
    public interface IUserService
    {
        Task<ValidationResult> NewUser(UserDTO userDTO);
        Task<User> GetById(int id);
        Task<ValidationResult> UpdateUser(int id, UserDTO user);
        Task<ValidationResult> DeleteUser(int id);
    }
}
