using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ASUniversity.Persistence.Implementations.Repositories
{
    internal class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentWithAppUserId(string id)
        {
            Student? student = await _context.Students.FirstOrDefaultAsync(x => x.AppUserId == id);
            if (student == null) throw new Exception("Student not found");
            return student;
        }
    }
}
