using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Faculty;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class FacultyService : IFacultyService

    {
        private readonly IFacultyRepository _repository;
        private readonly IMapper _mapper;

        public FacultyService(IFacultyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(FacultyCreateDto facultyCreateDto)
        {
            bool result = await _repository.AnyAsync(f => f.Name == facultyCreateDto.Name);
            if (result)
                throw new Exception("Faculty already exists");
            Faculty faculty = _mapper.Map<Faculty>(facultyCreateDto);
            await _repository.AddAsync(faculty);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Faculty faculty = await _repository.GetByIdAsync(id);
            _repository.Delete(faculty);
            await _repository.SaveChangesAsync();

        }

        public async Task<IEnumerable<FacultyItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Faculty> faculties = _repository.GetAll(skip: (page - 1) * take, take: take);
            return (_mapper.Map<IEnumerable<FacultyItemDto>>(faculties));
        }
        public async Task<IEnumerable<FacultyItemDto>> GetAllSelectAsync()
        {
            IEnumerable<Faculty> faculties = _repository.GetAllSelect();
            return (_mapper.Map<IEnumerable<FacultyItemDto>>(faculties));
        }
        public async Task<FacultyUpdateDto> GetByIdUpdateAsync(int id)
        {
            Faculty faculty = await _repository.GetByIdAsync(id);
            if (faculty is null) throw new Exception("Tapilmadi");
            FacultyUpdateDto facultyUpdateDto = _mapper.Map<FacultyUpdateDto>(faculty);
            return facultyUpdateDto;
        }

        public async Task Update(int id, FacultyUpdateDto facultyUpdateDto)
        {
            bool result = await _repository.AnyAsync(f => f.Name == facultyUpdateDto.Name && f.Id != id);
            if (result)
                throw new Exception("Faculty already exists");
            Faculty faculty = await _repository.GetByIdAsync(id);
            //faculty.Name = facultyUpdateDto.Name;
            _mapper.Map(facultyUpdateDto, faculty);
            await _repository.SaveChangesAsync();
        }
    }
}
