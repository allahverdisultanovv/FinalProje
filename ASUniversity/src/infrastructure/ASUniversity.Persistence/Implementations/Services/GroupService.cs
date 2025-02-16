using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Group;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(GroupCreateDto groupCreateDto)
        {
            bool result = await _repository.AnyAsync(s => s.Name == groupCreateDto.Name);
            if (result)
                throw new Exception("Group already exists");
            Group group = _mapper.Map<Group>(groupCreateDto);
            await _repository.AddAsync(group);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Group group = await _repository.GetByIdAsync(id);
            _repository.Delete(group);
            await _repository.SaveChangesAsync();

        }

        public async Task<IEnumerable<GroupItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Group> groups = _repository.GetAll(skip: (page - 1) * take, take: take, includes: ["Specialization"]);
            return (_mapper.Map<IEnumerable<GroupItemDto>>(groups));
        }

        public async Task<IEnumerable<GroupItemDto>> GetAllSelectAsync()
        {
            IEnumerable<Group> groups = _repository.GetAllSelect();
            IEnumerable<GroupItemDto> groupItems = _mapper.Map<IEnumerable<GroupItemDto>>(groups);
            return (groupItems);
        }

        public async Task<GroupUpdateDto> GetByIdUpdateAsync(int id)
        {

            Group group = await _repository.GetByIdAsync(id);
            if (group is null) throw new Exception("Tapilmadi");
            GroupUpdateDto GroupUpdateDto = _mapper.Map<GroupUpdateDto>(group);
            return GroupUpdateDto;
        }


        public async Task Update(int id, GroupUpdateDto groupUpdateDto)
        {
            if (await _repository.AnyAsync(s => s.Name == groupUpdateDto.Name && s.Id != id))
                throw new Exception("Group already exists");
            Group group = await _repository.GetByIdAsync(id);
            //Group.Name = GroupUpdateDto.Name;
            _mapper.Map(groupUpdateDto, group);
            await _repository.SaveChangesAsync();
        }
    }
}
