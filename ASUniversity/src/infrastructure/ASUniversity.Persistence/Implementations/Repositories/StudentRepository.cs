using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;

namespace ASUniversity.Persistence.Implementations.Repositories
{
    internal class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context) { }
    }
}
