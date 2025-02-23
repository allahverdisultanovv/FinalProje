using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Schedule;
using Microsoft.AspNetCore.Mvc;

namespace ASUniversity.MVC.Areas.Admin.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _service;

        public ScheduleController(IScheduleService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int grouupId)
        {
            IEnumerable<ScheduleItemDto> scheduleItemDtos = await _service.GetAllSelectAsync(grouupId);

            return View(scheduleItemDtos);
        }
    }
}
