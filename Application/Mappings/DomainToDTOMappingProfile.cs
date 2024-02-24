using Application.DTOs;
using AutoMapper;
using YogaOnline.Domain.Entities;

namespace Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
        }
    }
}
