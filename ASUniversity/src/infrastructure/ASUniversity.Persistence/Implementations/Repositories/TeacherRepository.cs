using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;

namespace ASUniversity.Persistence.Implementations.Repositories
{
    internal class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context) { }



    }
}
