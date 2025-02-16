using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Faculty;
using Microsoft.AspNetCore.Mvc;

namespace ASUniversity.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacultyController : Controller
    {
        private readonly IFacultyService _service;

        public FacultyController(IFacultyService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            IEnumerable<FacultyItemDto> facultyItemDtos = await _service.GetAllAsync(page, take);
            return View(facultyItemDtos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FacultyCreateDto facultyCreateDto)
        {

            if (!ModelState.IsValid) return View(facultyCreateDto);
            await _service.CreateAsync(facultyCreateDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            return View(await _service.GetByIdUpdateAsync(id.Value));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, FacultyUpdateDto facultyUpdateDto)
        {
            if (id < 1 || id is null) return BadRequest();
            await _service.Update(id.Value, facultyUpdateDto);
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
