using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using YogaOnline.Domain.Contracts.IRepositories;
using YogaOnline.Domain.Entities;

namespace Application.Implementations
{
    public class TeacherApplicationService : ApplicationServiceBase, ITeacherApplicationService
    {

        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherApplicationService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<Teacher> Register(Teacher teacher)
        {
            Teacher getTeacher = await _teacherRepository.GetByEmail(teacher.Email);

            if (getTeacher != null)
            {
                AddValidationError("Profissional já está cadastrado!", "Já existe um profissional cadastrado com o mesmo e-mail.");
            }

            getTeacher = new Teacher(
                    teacher.Name,
                    teacher.Email,
                    teacher.NumberRegister,
                    teacher.Profession,
                    teacher.SegmentationId);

            await _teacherRepository.Add(getTeacher);

            return getTeacher;
        }

        public async Task<IEnumerable<TeacherDTO>> GetAllSegmentation()
        {
            var teachers = _teacherRepository.GetAll();
            return await Task.FromResult(teachers.Select(x => new TeacherDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                NumberRegister = x.NumberRegister,
            }));
        }

        public async Task<IEnumerable<TeacherDTO>> GetByIdSegmentation(Guid id)
        {
            Teacher teacher = await _teacherRepository.GetById(id);

            if (teacher != null)
            {
                return new List<TeacherDTO>
                {
                    new TeacherDTO
                    {

                    }
                };
            }
            else
            {
                return Enumerable.Empty<TeacherDTO>();
            }
        }

        public async Task<IEnumerable<Teacher>> GetPagedTeachers(int pageIndex, int pageSize)
        {
            return await _teacherRepository.GetPagedTeachers(pageIndex, pageSize);
        }
    }
}
