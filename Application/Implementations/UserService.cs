using Application.Contracts;
using Application.DTOs;
using FluentValidation.Results;
using YogaOnline.Domain.Contracts.IRepositories;
using YogaOnline.Domain.Contracts.IServices;
using YogaOnline.Domain.Entities;


namespace Application.Implementations
{
    public class UserService : ApplicationServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileStorage _fileStorage;
        public UserService(IUserRepository userRepository, IFileStorage fileStorage)
        {
            _userRepository = userRepository;
            _fileStorage = fileStorage;
        }

        public async Task<ValidationResultDTO<User>> Register(UserDTO userDTO)
        {
            User user = await _userRepository.GetByEmail(userDTO.Email);

            if (user != null)
            {
                AddValidationError("Usuário já cadastrado.", "Já existe um usuário cadastrado com o mesmo e-mail.");
            }

            if (userDTO.Password != userDTO.ConfirmPassword)
            {
                throw new Exception("As senhas não correspondem.");
            }

            string hashedPassword = PasswordHasher.HashPassword(userDTO.Password);
            string hashedConfirmPassword = PasswordHasher.HashPassword(userDTO.ConfirmPassword);

            user = new User(
                userDTO.Name,
                userDTO.Email,
                userDTO.CPF,
                userDTO.Birthday,
                hashedPassword,
                hashedConfirmPassword);


            string imageURL = userDTO.File != null
                ? await _fileStorage.UploadFile(userDTO.File, user.Id.ToString())
                : "";


            user.UpdateImage(imageURL);

            await _userRepository.Add(user);

            return CustomValidationDataResponse<User>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {

            var users = _userRepository.GetAll();
            return await Task.FromResult(users.Select(x => new UserDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                CPF = x.Cpf,
                Birthday = x.Birthday
            }));
        }

        public async Task<ValidationResult> UpdateUser(UserDTO user)
        {
            
            User getUser = await _userRepository.GetByEmail(user.Email);

            if (getUser.IsValid())
            {
                getUser.UpdateUser(
                    user.Name,
                    user.Email,
                    user.CPF,
                    user.Birthday);

                _userRepository.Update(getUser);
            }
            else
            {
                return getUser.ValidationResult;
            }

            return getUser.ValidationResult;
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            User user = await _userRepository.GetById(id);

            return new UserDTO()
            {
                Id = id,
                Name = user.Name,
                Email = user.Email,
                CPF = user.Cpf,
                Birthday = user.Birthday
            };
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            User user = await _userRepository.GetById(id);

            if (user == null)
                return new ValidationResult();
            else
                _userRepository.Remove(user);

            return user.ValidationResult;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            User user = await _userRepository.GetByEmail(email);

            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CPF = user.Cpf, 
                Birthday = user.Birthday,
                ImageUrl = user.ImageURL

            };
        }

        public async Task<UserDTO> GetCPF(string cpf)
        {
            User user = await _userRepository.GetCPF(cpf);

            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CPF = user.Cpf,
                Birthday = user.Birthday
            };
        }

        public async Task<ValidationResult> UpdatePassword(Guid id, string password, string confirmPassword)
        {
            User user = await _userRepository.GetById(id);

            if (password != confirmPassword)
            {
                throw new Exception("As senhas não correspondem.");
            }

            string hashedPassword = PasswordHasher.HashPassword(password);
            string hashedConfirmPassword = PasswordHasher.HashPassword(confirmPassword);

            if (user.IsValid())
            {
                user.UpdatePassword(
                    hashedPassword,
                    hashedConfirmPassword);

                _userRepository.Update(user);
            }
            else
            {
                return user.ValidationResult;
            }

            return user.ValidationResult;
        }

        public async Task<ValidationResult> ForgotPassword(UserDTO dto)
        {
            User user = await _userRepository.GetByEmail(dto.Email);

            if (user.Email != dto.Email && user.Birthday != dto.Birthday && user.Cpf != dto.CPF)
            {
                throw new Exception("Não foi possivel alterar a senha. Contate o adm.");
            }

            bool correctData = user.ForgotPassword(dto.Email, dto.Birthday, dto.CPF);

            if ((dto.Password != dto.ConfirmPassword) || correctData == false)
            {
                throw new Exception("As senhas não correspondem.");
            }

            string hashedPassword = PasswordHasher.HashPassword(dto.Password);
            string hashedConfirmPassword = PasswordHasher.HashPassword(dto.ConfirmPassword);

            if (user.IsValid())
            {
                user.UpdatePassword(
                    hashedPassword,
                    hashedConfirmPassword);

                _userRepository.Update(user);
            }
            else
            {
                return user.ValidationResult;
            }

            return user.ValidationResult;
        }

        public async Task<ValidationResult> Login(string email, string password)
        {
            User user = await _userRepository.GetByEmail(email);

            string hashedPassword = PasswordHasher.HashPassword(password);

            bool login = user.Login(email, hashedPassword);

            if (!login)
            {
                throw new Exception("Não foi possivel fazer o login");
            }

            return user.ValidationResult;
        }
    }
}