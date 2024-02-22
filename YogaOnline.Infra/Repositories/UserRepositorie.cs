using Microsoft.EntityFrameworkCore;
using YogaOnline.Domain.Contracts.IRepositories;
using YogaOnline.Domain.Entities;
using YogaOnline.Infra.Context;

namespace YogaOnline.Infra.Repositories
{
    public class UserRepositorie : RepositoryBase<User>, IUserRepository
    {

        public UserRepositorie(MicroServiceContext context) : base(context)
        {
        }

        public Task<User> GetByEmail(string email)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User> GetCPF(string cpf)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Cpf == cpf);
        }
    }
}
