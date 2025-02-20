using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Exam;
using ASUniversity.Domain.Entities;
using AutoMapper;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class ExamService : IExamService
    {

        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;

        public ExamService(IExamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ExamCreateDto examCreateDto)
        {
            Exam exam = _mapper.Map<Exam>(examCreateDto);
            await _repository.AddAsync(exam);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Exam exam = await _repository.GetByIdAsync(id);
            _repository.Delete(exam);
            await _repository.SaveChangesAsync();

        }

        public async Task<IEnumerable<ExamItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Exam> exams = _repository.GetAll(skip: (page - 1) * take, take: take);
            return (_mapper.Map<IEnumerable<ExamItemDto>>(exams));
        }
        public async Task<IEnumerable<ExamItemDto>> GetAllSelectAsync()
        {
            IEnumerable<Exam> exams = _repository.GetAllSelect();
            return (_mapper.Map<IEnumerable<ExamItemDto>>(exams));
        }
        public async Task<ExamUpdateDto> GetByIdUpdateAsync(int id)
        {
            Exam exam = await _repository.GetByIdAsync(id);
            if (exam is null) throw new Exception("Tapilmadi");
            ExamUpdateDto examUpdateDto = _mapper.Map<ExamUpdateDto>(exam);
            return examUpdateDto;
        }

        public async Task Update(int id, ExamUpdateDto examUpdateDto)
        {
            Exam exam = await _repository.GetByIdAsync(id);
            //Exam.Name = ExamUpdateDto.Name;
            _mapper.Map(examUpdateDto, exam);
            await _repository.SaveChangesAsync();
        }
    }
}
