using ASUniversity.Application.DTOs.Specialization;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Application.MappingProfiles
{
    public class SpecializationProfile : Profile
    {
        public SpecializationProfile()
        {
            CreateMap<Specialization, SpecializationItemDto>()
              .ForCtorParam(nameof(SpecializationItemDto.GroupCount),
              opt => opt.MapFrom(
                  s => s.Groups.Count()
                  )
              ).ForCtorParam(nameof(SpecializationItemDto.Faculty),
                opt => opt.MapFrom(s => s.Faculty.Name)
                )
               ;
            CreateMap<SpecializationCreateDto, Specialization>();
            CreateMap<SpecializationUpdateDto, Specialization>().ReverseMap();

        }
    }
}
