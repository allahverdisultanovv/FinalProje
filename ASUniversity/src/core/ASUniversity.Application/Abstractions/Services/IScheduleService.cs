using ASUniversity.Application.Dtos.Schedule;

namespace ASUniversity.Application.Abstractions.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleItemDto>> GetAllAsync(int page, int take);
        Task<IEnumerable<ScheduleItemDto>> GetAllSelectAsync();
        Task CreateAsync(ScheduleCreateDto scheduleCreateDto);
        Task Delete(int id);
        Task Update(int id, ScheduleUpdateDto scheduleUpdateDto);
        Task<ScheduleUpdateDto> GetByIdUpdateAsync(int id);
    }
}
