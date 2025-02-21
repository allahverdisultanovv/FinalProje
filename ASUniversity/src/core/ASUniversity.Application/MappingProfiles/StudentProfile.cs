using ASUniversity.Application.DTOs.Student;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Application.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {

            CreateMap<Student, GetStudentDto>()
                    .ForCtorParam(nameof(GetStudentDto.Group),
                    opt => opt.MapFrom(s => s.Group.Name))
                    .ForCtorParam(nameof(GetStudentDto.Degree),
                    opt => opt.MapFrom(s => s.Degree.ToString()))
                    .ForCtorParam(nameof(GetStudentDto.Name),
                    opt => opt.MapFrom(s => s.AppUser.Name))
                    .ForCtorParam(nameof(GetStudentDto.Surname),
                    opt => opt.MapFrom(s => s.AppUser.Surname))
                    .ForCtorParam(nameof(GetStudentDto.Email),
                    opt => opt.MapFrom(s => s.AppUser.Email))
                    .ForCtorParam(nameof(GetStudentDto.Username),
                    opt => opt.MapFrom(s => s.AppUser.UserName))
                    .ForCtorParam(nameof(GetStudentDto.Image),
                    opt => opt.MapFrom(s => s.AppUser.Image))
                     .ForCtorParam(nameof(GetStudentDto.BirthDay),
                    opt => opt.MapFrom(s => s.AppUser.Birthday))
                    .ForCtorParam(nameof(GetStudentDto.Age),
                    opt => opt.MapFrom(s => DateTime.Now.Year - s.AppUser.Birthday.Year));
        }
    }
}
