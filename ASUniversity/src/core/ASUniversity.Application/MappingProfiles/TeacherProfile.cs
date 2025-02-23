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
                .ForMember(nameof(GetTeacherDto.Faculty),
                opt => opt.MapFrom(t => t.Faculty.Name))
                .ForMember(nameof(GetTeacherDto.Position),
                opt => opt.MapFrom(t => t.Position.ToString()))
                .ForMember(nameof(GetTeacherDto.Name),
                opt => opt.MapFrom(t => t.AppUser.Name))
                .ForMember(nameof(GetTeacherDto.Surname),
                opt => opt.MapFrom(t => t.AppUser.Surname))
                .ForMember(nameof(GetTeacherDto.Email),
                opt => opt.MapFrom(t => t.AppUser.Email))
                .ForMember(nameof(GetTeacherDto.Username),
                opt => opt.MapFrom(t => t.AppUser.UserName))
                .ForMember(nameof(GetTeacherDto.Image),
                opt => opt.MapFrom(t => t.AppUser.Image))
                .ForMember(nameof(GetTeacherDto.BirthDay),
                opt => opt.MapFrom(t => t.AppUser.Birthday))
                .ForMember(nameof(GetTeacherDto.Age),
                opt => opt.MapFrom(t => DateTime.Now.Year - t.AppUser.Birthday.Year));

        }
    }
}
