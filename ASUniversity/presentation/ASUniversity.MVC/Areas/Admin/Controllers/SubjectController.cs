using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Subject;
using Microsoft.AspNetCore.Mvc;

namespace ASUniversity.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService _service;
        private readonly IFacultyService _facultyService;

        public SubjectController(ISubjectService service, IFacultyService facultyService)
        {
            _service = service;
            _facultyService = facultyService;
        }
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            IEnumerable<SubjectItemDto> subjectItemDtos = await _service.GetAllAsync(page, take);
            return View(subjectItemDtos);
        }
        public async Task<IActionResult> Create()
        {
            SubjectCreateDto subjectCreateDto = new SubjectCreateDto()
            {
                Faculties = await _facultyService.GetAllSelectAsync()
            };
            return View(subjectCreateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubjectCreateDto subjectCreateDto)
        {
            subjectCreateDto.Faculties = await _facultyService.GetAllSelectAsync();
            if (!ModelState.IsValid) return View(subjectCreateDto);
            await _service.CreateAsync(subjectCreateDto, ModelState);
            if (ModelState.ErrorCount > 0)
            {
                ModelState.AddModelError(nameof(subjectCreateDto.Name), "slam");
                return View(subjectCreateDto);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            SubjectUpdateDto subjectUpdateDto = await _service.GetByIdUpdateAsync(id.Value);
            subjectUpdateDto.Faculties = await _facultyService.GetAllSelectAsync();

            return View(subjectUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, SubjectUpdateDto subjectUpdateDto)
        {
            if (id < 1 || id is null) return BadRequest();
            await _service.Update(id.Value, subjectUpdateDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id < 1 || id is null) return BadRequest();
            await _service.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
