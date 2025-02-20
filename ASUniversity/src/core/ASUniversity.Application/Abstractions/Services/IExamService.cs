using ASUniversity.Application.DTOs.Exam;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface IExamService
    {
        Task<IEnumerable<ExamItemDto>> GetAllAsync(int page, int take);
        Task<IEnumerable<ExamItemDto>> GetAllSelectAsync();

        Task CreateAsync(ExamCreateDto examCreateDto);
        Task Delete(int id);
        Task Update(int id, ExamUpdateDto examUpdateDto);
        Task<ExamUpdateDto> GetByIdUpdateAsync(int id);
    }
}
