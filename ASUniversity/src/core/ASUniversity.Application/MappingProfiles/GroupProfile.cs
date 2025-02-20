using ASUniversity.Application.DTOs.Group;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Application.MappingProfiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupItemDto>()


                .ForCtorParam(nameof(GroupItemDto.Specialization),
                opt => opt.MapFrom(g => g.Specialization.Name))
                ;
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupUpdateDto, Group>().ReverseMap();
        }
    }
}
