using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Group;
using Microsoft.AspNetCore.Mvc;

namespace ASUniversity.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
        private readonly IGroupService _service;
        private readonly ISpecializationService _specializationService;

        public GroupController(IGroupService service, ISpecializationService specializationService)
        {
            _service = service;
            _specializationService = specializationService;
        }
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            IEnumerable<GroupItemDto> groupItemDtos = await _service.GetAllAsync(page, take);
            return View(groupItemDtos);
        }
        public async Task<IActionResult> Create()
        {
            GroupCreateDto groupCreateDto = new GroupCreateDto()
            {
                Specializations = await _specializationService.GetAllSelectAsync()
            };
            return View(groupCreateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GroupCreateDto groupCreateDto)
        {

            if (!ModelState.IsValid) return View(groupCreateDto);
            await _service.CreateAsync(groupCreateDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            GroupUpdateDto groupUpdateDto = await _service.GetByIdUpdateAsync(id.Value);
            groupUpdateDto.Specializations = await _specializationService.GetAllSelectAsync();
            return View(groupUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, GroupUpdateDto groupUpdateDto)
        {
            if (id < 1 || id is null) return BadRequest();
            await _service.Update(id.Value, groupUpdateDto);
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
