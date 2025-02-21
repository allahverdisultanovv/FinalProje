using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Student;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Persistence.Implementations.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(Student student)
        {
            await _repository.AddAsync(student);
            await _repository.SaveChangesAsync();
        }



        public async Task<GetStudentDto> GetIndex(string id)
        {
            GetStudentDto getStudentDto = _mapper.Map<GetStudentDto>(await _repository.GetStudentWithAppUserId(id));
            return getStudentDto;
        }
    }
}
