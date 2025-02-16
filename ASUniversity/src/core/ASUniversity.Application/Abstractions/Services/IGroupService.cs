using ASUniversity.Application.DTOs.Group;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupItemDto>> GetAllAsync(int page, int take);
        Task<IEnumerable<GroupItemDto>> GetAllSelectAsync();

        Task CreateAsync(GroupCreateDto groupCreateDto);
        Task Delete(int id);
        Task Update(int id, GroupUpdateDto groupUpdateDto);
        Task<GroupUpdateDto> GetByIdUpdateAsync(int id);
    }
}
