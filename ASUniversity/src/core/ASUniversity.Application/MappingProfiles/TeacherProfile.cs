using ASUniversity.Application.DTOs.Teacher;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Application.MappingProfiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherItemDto>()
               .ForCtorParam(nameof(TeacherItemDto.Faculty),
               opt => opt.MapFrom(
                   t => t.Faculty.Name
                   ))
               .ForCtorParam(nameof(TeacherItemDto.Name),
               opt => opt.MapFrom(
                   t => t.AppUser.Name));
        }
    }
}
