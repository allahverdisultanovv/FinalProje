using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;

namespace ASUniversity.Persistence.Implementations.Repositories
{
    internal class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(AppDbContext context) : base(context) { }
    }
}
