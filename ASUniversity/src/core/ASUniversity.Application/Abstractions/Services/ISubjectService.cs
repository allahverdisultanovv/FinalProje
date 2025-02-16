using ASUniversity.Application.DTOs.Subject;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface ISubjectService
    {
        public Task<IEnumerable<SubjectItemDto>> GetAllAsync(int page, int take);
        Task CreateAsync(SubjectCreateDto subjectCreateDto);
        Task Delete(int id);
        Task Update(int id, SubjectUpdateDto subjectUpdateDto);
        Task<SubjectUpdateDto> GetByIdUpdateAsync(int id);
        //Task<SubjectCreateDto> GetByIdCreateAsync(int id);

    }
}
