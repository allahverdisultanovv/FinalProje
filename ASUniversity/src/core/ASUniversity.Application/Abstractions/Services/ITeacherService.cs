using ASUniversity.Application.DTOs.Teacher;
using ASUniversity.Domain.Entities;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface ITeacherService
    {
        Task CreateAsync(Teacher teacher);
        Task<IEnumerable<TeacherItemDto>> GetAllSelectAsync();
        Task<GetTeacherDto> GetIndex(string id);

    }
}
