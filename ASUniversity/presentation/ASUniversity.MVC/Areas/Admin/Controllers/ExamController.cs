using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Exam;
using ASUniversity.Domain.Enums;
using ASUniversity.Persistence.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASUniversity.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExamController : Controller
    {
        private readonly IExamService _service;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly IGroupService _groupService;

        public ExamController(IExamService service, ISubjectService subjectService, ITeacherService teacherService, IGroupService groupService)
        {
            _service = service;
            _subjectService = subjectService;
            _groupService = groupService;
        }
        public async Task<IActionResult> Index(int page, int take)
        {
            IEnumerable<ExamItemDto> exams = await _service.GetAllAsync(page, take);
            return View(exams);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ExamCreateDto examDto = new ExamCreateDto()
            {
                Groups = await _groupService.GetAllSelectAsync(),
                Teachers = await _teacherService.GetAllSelectAsync(),
                ExamTypes = Enum.GetValues(typeof(ExamType))
                        .Cast<ExamType>()
                        .Select(p => new SelectListItem
                        {
                            Value = ((int)p).ToString(),
                            Text = EnumHelper.GetEnumDescription(p)
                        })
                        .ToList(),
                Subjects = await _subjectService.GetAllSelectAsync()
            };
            return View(examDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ExamCreateDto examCreateDto)
        {
            if (!ModelState.IsValid) return View(examCreateDto);
            await _service.CreateAsync(examCreateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
