using ASUniversity.Application.DTOs.Faculty;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface IFacultyService
    {
        Task<IEnumerable<FacultyItemDto>> GetAllAsync(int page, int take);
        Task<IEnumerable<FacultyItemDto>> GetAllSelectAsync();

        Task CreateAsync(FacultyCreateDto facultyCreateDto);
        Task Delete(int id);
        Task Update(int id, FacultyUpdateDto facultyUpdateDto);
        Task<FacultyUpdateDto> GetByIdUpdateAsync(int id);

    }
}
