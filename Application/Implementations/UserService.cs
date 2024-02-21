using Application.Contracts;
using Application.DTOs;
using FluentValidation.Results;
using YogaOnline.Domain.Contracts.IRepositories;
using YogaOnline.Domain.Entities;


namespace Application.Implementations
{
    public class UserService : ApplicationServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ValidationResult> NewUser(UserDTO userDTO)
        {
            User user = await _userRepository.GetByEmail(userDTO.Email);

            user = new User(
                userDTO.Name,
                userDTO.Email);

            await _userRepository.Add(user);

            return user.ValidationResult;
        }


        public async Task<User> GetById(int id)
        {
            User user = await _userRepository.GetById(id);

            return user;
        }

        public async Task<ValidationResult> UpdateUser(int id, UserDTO user)
        {

            User getUser = await _userRepository.GetById(id);
            if (user == null)
                AddValidationError("Usuario não encontrada.", "Não existe nenhum usuario cadastrado na base com esse id.");
            else
            {
                getUser.UpdateUser(user.Name, user.Email);
                _userRepository.Update(getUser);
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> DeleteUser(int id)
        {
            User getUser = await _userRepository.GetById(id);

            if (getUser == null)
                AddValidationError("Usuario não encontrado.", "Não existe nenhum usuario cadastrado na base com esse id.");
            else
            {
                _userRepository.Remove(getUser);
            }

            return ValidationResult;
        }
    }
}