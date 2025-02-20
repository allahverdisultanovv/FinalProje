using ASUniversity.Application.DTOs.Subject;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Application.MappingProfiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectItemDto>()
                .ForCtorParam(nameof(SubjectItemDto.Faculty),
                opt => opt.MapFrom(p => p.Faculty.Name)
                );

            CreateMap<SubjectCreateDto, Subject>().ReverseMap();
            CreateMap<SubjectUpdateDto, Subject>().ReverseMap();


        }
    }
}
