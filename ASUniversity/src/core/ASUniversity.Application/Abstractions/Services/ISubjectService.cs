using ASUniversity.Application.DTOs.Subject;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface ISubjectService
    {
        public Task<IEnumerable<SubjectItemDto>> GetAllAsync(int page, int take);
        Task<IEnumerable<SubjectItemDto>> GetAllSelectAsync();

        Task CreateAsync(SubjectCreateDto subjectCreateDto, ModelStateDictionary modelstate);
        Task Delete(int id);
        Task Update(int id, SubjectUpdateDto subjectUpdateDto);
        Task<SubjectUpdateDto> GetByIdUpdateAsync(int id);
        //Task<SubjectCreateDto> GetByIdCreateAsync(int id);

    }
}
