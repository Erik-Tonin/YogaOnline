using YogaOnline.Domain.Entities;

namespace YogaOnline.Domain.Contracts.IRepositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
        Task<User> GetCPF(string cpf);
    }
}
