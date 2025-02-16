using ASUniversity.Application.DTOs.Specialization;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface ISpecializationService
    {
        public Task<IEnumerable<SpecializationItemDto>> GetAllAsync(int page, int take);
        Task CreateAsync(SpecializationCreateDto specializationCreateDto);
        Task<IEnumerable<SpecializationItemDto>> GetAllSelectAsync();

        Task Delete(int id);
        Task Update(int id, SpecializationUpdateDto specializationUpdateDto);
        Task<SpecializationUpdateDto> GetByIdUpdateAsync(int id);
    }
}
