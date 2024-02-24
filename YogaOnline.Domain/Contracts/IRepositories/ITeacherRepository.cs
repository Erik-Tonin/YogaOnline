using YogaOnline.Domain.Entities;

namespace YogaOnline.Domain.Contracts.IRepositories
{
    public interface ITeacherRepository : IRepositoryBase<Teacher>
    {
        Task<Teacher> GetByEmail(string email);
        //Task<IEnumerable<Teacher>> GetAllTeachers(Teacher dto);
        Task<IEnumerable<Teacher>> GetPagedTeachers(int pageIndex, int pageSize);
    }
}
