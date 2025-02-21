using ASUniversity.Domain.Entities;

namespace ASUniversity.Application.Abstractions.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher> GetTeacherWithAppUserId(string id);

    }
}
