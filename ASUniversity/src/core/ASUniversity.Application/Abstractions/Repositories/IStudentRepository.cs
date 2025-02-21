using ASUniversity.Domain.Entities;

namespace ASUniversity.Application.Abstractions.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetStudentWithAppUserId(string id);

    }
}
