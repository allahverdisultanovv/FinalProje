using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ASUniversity.Persistence.Implementations.Repositories
{
    internal class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Teacher> GetTeacherWithAppUserId(string id)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.AppUserId == id);
            if (teacher == null) throw new Exception("Teacher not found");
            return teacher;
        }
    }
}
