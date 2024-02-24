using Microsoft.EntityFrameworkCore;
using YogaOnline.Domain.Contracts.IRepositories;
using YogaOnline.Domain.Entities;
using YogaOnline.Infra.Context;

namespace YogaOnline.Infra.Repositories
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {

        public TeacherRepository(MicroServiceContext context) : base(context)
        {
        }

        public Task<Teacher> GetByEmail(string email)
        {
            return _context.Teachers.FirstOrDefaultAsync(x => x.Email == email);
        }

        //public async Task<IEnumerable<Teacher>> GetAllTeachers(Teacher teacherDTO)
        //{
        //    IQueryable<Teacher> query = _context.Teachers.AsQueryable();

        //    query = query.OrderBy(x => x.Name)
        //                 .Skip(teacherDTO.PageIndex)
        //                 .Take(teacherDTO.PageSize);

        //    return await query.ToListAsync();
        //}

        public async Task<IEnumerable<Teacher>> GetPagedTeachers(int pageIndex, int pageSize)
        {
            IQueryable<Teacher> query = _context.Teachers.AsQueryable();

            query = query.OrderBy(x => x.Name)
                         .Skip(pageIndex)
                         .Take(pageSize);

            return await query.ToListAsync();
        }
    }
}
