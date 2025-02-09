using ASUniversity.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASUniversity.MVC.Areas.Admin.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _service.GetAllAsync(1, 3));
        }
    }
}
