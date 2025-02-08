using ASUniversity.Domain.Entities;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface ISubjectService
    {
        public Task<IEnumerable<Subject>> GetAllAsync
    }
}
