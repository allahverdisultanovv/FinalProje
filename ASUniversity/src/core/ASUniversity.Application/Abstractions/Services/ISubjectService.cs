using ASUniversity.Application.DTOs.Subject;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface ISubjectService
    {
        public Task<IEnumerable<SubjectItemDto>> GetAllAsync(int page, int take);
    }
}
