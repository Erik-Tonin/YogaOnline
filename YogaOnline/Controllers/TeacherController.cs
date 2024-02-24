using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaOnline.Domain.Entities;

namespace YogaOnline.Controllers
{
    public class TeacherController : ApiController
    {
        private readonly ITeacherApplicationService _teacherApplicationService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherApplicationService teacherApplicationService, IMapper mapper)
        {
            _teacherApplicationService = teacherApplicationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("RegisterTeacher")]
        public async Task<Teacher> RegisterTeacher(Teacher teacher)
        {
            Teacher teacherRegister = await _teacherApplicationService.Register(teacher);

            return teacherRegister;
        }

        [AllowAnonymous]
        [HttpGet("GetAllSegmentation")]
        public async Task<IEnumerable<TeacherDTO>> GetAllSegmentation()
        {
            return await _teacherApplicationService.GetAllSegmentation();
        }

        [AllowAnonymous]
        [HttpGet("GetByIdSegmentation")]
        public async Task<IEnumerable<TeacherDTO>> GetByIdSegmentation(int id)
        {
            return await _teacherApplicationService.GetByIdSegmentation(id);
        }

        [AllowAnonymous]
        [HttpGet("GetPagedTeachers")]
        public async Task<IEnumerable<TeacherDTO>> GetPagedTeachers(TeacherDTO teacherDTO)
        {
            var teachers = await _teacherApplicationService.GetPagedTeachers(teacherDTO.PageIndex, teacherDTO.PageSize);
            return _mapper.Map<IEnumerable<TeacherDTO>>(teachers);
        }
    }
}
