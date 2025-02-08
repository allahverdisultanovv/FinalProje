using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;

namespace ASUniversity.Persistence.Implementations.Repositories
{
    internal class FacultyRepository : Repository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(AppDbContext context) : base(context) { }
    }
}
