using ASUniversity.Application.DTOs.Exam;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Application.MappingProfiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamItemDto>()
                .ForCtorParam(nameof(ExamItemDto.Group),
                opt => opt.MapFrom(
                    g => g.Group.Name
                    )
                ).ForCtorParam(nameof(ExamItemDto.Teacher),
                opt => opt.MapFrom(
                    g => g.Teacher.AppUser.Name
                    )
                ).ForCtorParam(nameof(ExamItemDto.Type),
                opt => opt.MapFrom(
                    g => g.ExamType.ToString()
                    )
                );
            CreateMap<ExamCreateDto, Exam>();
            CreateMap<ExamUpdateDto, Exam>().ReverseMap();
        }
    }
}
