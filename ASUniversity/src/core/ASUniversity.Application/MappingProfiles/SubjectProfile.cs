using ASUniversity.Application.DTOs.Subject;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Application.MappingProfiles
{
    internal class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectItemDto>();

        }
    }
}
