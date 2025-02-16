using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Specialization;
using Microsoft.AspNetCore.Mvc;

namespace ASUniversity.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecializationController : Controller
    {
        private readonly ISpecializationService _service;
        private readonly IFacultyService _facultyService;

        public SpecializationController(ISpecializationService service, IFacultyService facultyService)
        {
            _service = service;
            _facultyService = facultyService;
        }
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            IEnumerable<SpecializationItemDto> specializationItemDtos = await _service.GetAllAsync(page, take);
            return View(specializationItemDtos);
        }
        public async Task<IActionResult> Create()
        {
            SpecializationCreateDto specializationCreateDto = new SpecializationCreateDto()
            {
                Faculties = await _facultyService.GetAllSelectAsync()
            };
            return View(specializationCreateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpecializationCreateDto specializationCreateDto)
        {

            if (!ModelState.IsValid) return View(specializationCreateDto);
            await _service.CreateAsync(specializationCreateDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            SpecializationUpdateDto specializationUpdateDto = await _service.GetByIdUpdateAsync(id.Value);
            specializationUpdateDto.Faculties = await _facultyService.GetAllSelectAsync();
            return View(specializationUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, SpecializationUpdateDto specializationUpdateDto)
        {
            if (id < 1 || id is null) return BadRequest();
            await _service.Update(id.Value, specializationUpdateDto);
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
