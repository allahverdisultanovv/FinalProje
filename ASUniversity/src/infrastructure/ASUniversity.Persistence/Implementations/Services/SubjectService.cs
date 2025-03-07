﻿using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Subject;
using ASUniversity.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        private readonly IMapper _mapper;
        public SubjectService(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(SubjectCreateDto subjectCreateDto, ModelStateDictionary modelstate)
        {
            bool result = await _repository.AnyAsync(s => s.Name == subjectCreateDto.Name);
            if (result)
                modelstate.AddModelError(string.Empty, "subject aready exist");
            else
            {

                Subject subject = new Subject()
                {
                    FacultyId = subjectCreateDto.FacultyId,
                    Name = subjectCreateDto.Name,
                    Credits = subjectCreateDto.Credits,

                };
                await _repository.AddAsync(subject);
                await _repository.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            Subject subject = await _repository.GetByIdAsync(id);
            _repository.Delete(subject);
            await _repository.SaveChangesAsync();

        }
        public async Task<IEnumerable<SubjectItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Subject> subjects = _repository.GetAll(skip: (page - 1) * take, take: take, includes: ["Faculty"]);
            return (_mapper.Map<IEnumerable<SubjectItemDto>>(subjects));
        }
        public async Task<IEnumerable<SubjectItemDto>> GetAllSelectAsync()
        {
            IEnumerable<Subject> subjects = _repository.GetAllSelect("Faculty");
            IEnumerable<SubjectItemDto> subjectItems = _mapper.Map<IEnumerable<SubjectItemDto>>(subjects);
            return (subjectItems);
        }
        public async Task<SubjectUpdateDto> GetByIdUpdateAsync(int id)
        {
            Subject subject = await _repository.GetByIdAsync(id);
            if (subject is null) throw new Exception("Tapilmadi");
            SubjectUpdateDto subjectUpdateDto = _mapper.Map<SubjectUpdateDto>(subject);
            return subjectUpdateDto;
        }
        public async Task Update(int id, SubjectUpdateDto subjectUpdateDto)
        {
            if (await _repository.AnyAsync(s => s.Name == subjectUpdateDto.Name && s.Id != id))
                throw new Exception("Subject already exists");
            Subject subject = await _repository.GetByIdAsync(id);
            _mapper.Map(subjectUpdateDto, subject);
            await _repository.SaveChangesAsync();
        }
    }
}
