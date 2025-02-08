using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;

namespace ASUniversity.Persistence.Implementations.Repositories
{
    internal class ExamResultRepository : Repository<ExamResult>, IExamResultRepository
    {
        public ExamResultRepository(AppDbContext context) : base(context) { }
    }
}
