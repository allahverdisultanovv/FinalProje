using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Domain.Entities;

namespace ASUniversity.Persistence.Implementations.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Student student)
        {
            await _repository.AddAsync(student);
            await _repository.SaveChangesAsync();
        }
    }
}
