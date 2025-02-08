using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;

namespace ASUniversity.Persistence.Implementations.Repositories
{
    internal class SpecializationRepository : Repository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(AppDbContext context) : base(context) { }
    }
}
