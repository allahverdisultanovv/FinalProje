using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Teacher;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(Teacher teacher)
        {
            await _repository.AddAsync(teacher);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TeacherItemDto>> GetAllSelectAsync()
        {
            IEnumerable<Teacher> teachers = _repository.GetAllSelect();
            IEnumerable<TeacherItemDto> teacherItems = _mapper.Map<IEnumerable<TeacherItemDto>>(teachers);
            return (teacherItems);
        }
    }
}
