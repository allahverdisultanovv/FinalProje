using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Subject;
using ASUniversity.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SubjectItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Subject> subjects = await _repository.GetAll(skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<IEnumerable<SubjectItemDto>>(subjects);
        }
    }
}
