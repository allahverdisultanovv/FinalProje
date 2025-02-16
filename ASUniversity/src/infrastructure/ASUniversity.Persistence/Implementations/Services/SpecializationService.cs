using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Specialization;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;

        public SpecializationService(ISpecializationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SpecializationCreateDto specializationCreateDto)
        {
            bool result = await _repository.AnyAsync(s => s.Name == specializationCreateDto.Name);
            if (result)
                throw new Exception("Specialization already exists");
            Specialization specialization = _mapper.Map<Specialization>(specializationCreateDto);
            await _repository.AddAsync(specialization);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Specialization specialization = await _repository.GetByIdAsync(id);
            _repository.Delete(specialization);
            await _repository.SaveChangesAsync();

        }

        public async Task<IEnumerable<SpecializationItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Specialization> specializations = _repository.GetAll(skip: (page - 1) * take, take: take, includes: ["Faculty"]);
            return (_mapper.Map<IEnumerable<SpecializationItemDto>>(specializations));
        }
        public async Task<IEnumerable<SpecializationItemDto>> GetAllSelectAsync()
        {
            IEnumerable<Specialization> specializations = _repository.GetAllSelect();
            return (_mapper.Map<IEnumerable<SpecializationItemDto>>(specializations));
        }
        public async Task<SpecializationUpdateDto> GetByIdUpdateAsync(int id)
        {
            Specialization specialization = await _repository.GetByIdAsync(id);
            if (specialization is null) throw new Exception("Tapilmadi");
            SpecializationUpdateDto SpecializationUpdateDto = _mapper.Map<SpecializationUpdateDto>(specialization);
            return SpecializationUpdateDto;
        }

        public async Task Update(int id, SpecializationUpdateDto SpecializationUpdateDto)
        {
            bool result = await _repository.AnyAsync(s => s.Name == SpecializationUpdateDto.Name && s.Id != id);
            if (result)
                throw new Exception("Specialization already exists");
            Specialization specialization = await _repository.GetByIdAsync(id);
            //Specialization.Name = SpecializationUpdateDto.Name;
            _mapper.Map(SpecializationUpdateDto, specialization);
            await _repository.SaveChangesAsync();
        }
    }
}
