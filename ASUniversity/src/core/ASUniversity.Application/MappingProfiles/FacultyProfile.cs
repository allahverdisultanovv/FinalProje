using ASUniversity.Application.DTOs.Faculty;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Application.MappingProfiles
{
    internal class FacultyProfile : Profile
    {
        public FacultyProfile()
        {
            CreateMap<Faculty, FacultyItemDto>()
                .ForCtorParam(nameof(FacultyItemDto.StudentCount),
                opt => opt.MapFrom(
                    p => p.Students.Count()
                    )
                ).ForCtorParam(nameof(FacultyItemDto.TeacherCount),
                opt => opt.MapFrom(
                    p => p.Teachers.Count()
                    )
                ).ForCtorParam(nameof(FacultyItemDto.SpecializationCount),
                opt => opt.MapFrom(
                    p => p.Specializations.Count()
                    )
                );
            CreateMap<FacultyCreateDto, Faculty>();
            CreateMap<FacultyUpdateDto, Faculty>().ReverseMap();

        }
    }
}
