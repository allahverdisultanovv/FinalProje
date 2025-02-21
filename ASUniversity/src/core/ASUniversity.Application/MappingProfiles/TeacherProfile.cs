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
            CreateMap<Teacher, GetTeacherDto>()
                .ForCtorParam(nameof(GetTeacherDto.Faculty),
                opt => opt.MapFrom(t => t.Faculty.Name))
                .ForCtorParam(nameof(GetTeacherDto.Position),
                opt => opt.MapFrom(t => t.Position.ToString()))
                .ForCtorParam(nameof(GetTeacherDto.Name),
                opt => opt.MapFrom(t => t.AppUser.Name))
                .ForCtorParam(nameof(GetTeacherDto.Surname),
                opt => opt.MapFrom(t => t.AppUser.Surname))
                .ForCtorParam(nameof(GetTeacherDto.Email),
                opt => opt.MapFrom(t => t.AppUser.Email))
                .ForCtorParam(nameof(GetTeacherDto.Username),
                opt => opt.MapFrom(t => t.AppUser.UserName))
                .ForCtorParam(nameof(GetTeacherDto.Image),
                opt => opt.MapFrom(t => t.AppUser.Image))
                .ForCtorParam(nameof(GetTeacherDto.BirthDay),
                opt => opt.MapFrom(t => t.AppUser.Birthday))
                .ForCtorParam(nameof(GetTeacherDto.Age),
                opt => opt.MapFrom(t => DateTime.Now.Year - t.AppUser.Birthday.Year));

        }
    }
}
