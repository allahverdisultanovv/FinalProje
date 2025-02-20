using ASUniversity.Domain.Entities;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface IStudentService
    {
        //Task<IEnumerable<FacultyItemDto>> GetAllAsync(int page, int take);
        //Task<IEnumerable<FacultyItemDto>> GetAllSelectAsync();

        //Task Delete(int id);
        Task CreateAsync(Student student);
    }
}
