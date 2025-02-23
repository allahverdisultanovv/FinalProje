using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Schedule;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(ScheduleCreateDto scheduleCreateDto)
        {

            await _repository.AddAsync(_mapper.Map<Schedule>(scheduleCreateDto));
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Schedule schedule = await _repository.GetByIdAsync(id);
            _repository.Delete(schedule);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ScheduleItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Schedule> schedules = _repository.GetAll(skip: (page - 1) * take, take: take, includes: ["Teacher", "Group", "Subject"]);
            return (_mapper.Map<IEnumerable<ScheduleItemDto>>(schedules));
        }

        public async Task<IEnumerable<ScheduleItemDto>> GetAllSelectAsync(int? id)
        {

            IEnumerable<Schedule> schedules = _repository.GetAll(whereExpression: t => t.GroupId == id, includes: ["Teacher", "Group", "Subject"]);
            return (_mapper.Map<IEnumerable<ScheduleItemDto>>(schedules));
        }


        public async Task<ScheduleUpdateDto> GetByIdUpdateAsync(int id)
        {
            Schedule schedule = await _repository.GetByIdAsync(id);
            if (schedule is null) throw new Exception("Tapilmadi");
            ScheduleUpdateDto scheduleUpdateDto = _mapper.Map<ScheduleUpdateDto>(schedule);
            return scheduleUpdateDto;
        }

        public async Task Update(int id, ScheduleUpdateDto scheduleUpdateDto)
        {

            Schedule schedule = await _repository.GetByIdAsync(id);
            _mapper.Map(scheduleUpdateDto, schedule);
            await _repository.SaveChangesAsync();
        }
    }
}
