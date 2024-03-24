using Application.DTOs;
using YogaOnline.Domain.Entities;

namespace Application.Contracts
{
    public interface ITeacherApplicationService
    {
        Task<Teacher> Register(Teacher teacher);
        Task<IEnumerable<TeacherDTO>> GetAllSegmentation();
        Task<IEnumerable<TeacherDTO>> GetByIdSegmentation(Guid id);
        Task<IEnumerable<Teacher>> GetPagedTeachers(int pageIndex, int pageSize);
    }
}
