using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASUniversity.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public UserController(ITeacherService teacherService, IStudentService studentService)
        {
            _teacherService = teacherService;
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            GetUserDto getUserDto = new GetUserDto();


            if (User.IsInRole("Teacher"))
            {


                getUserDto.Teacher = await _teacherService.GetIndex(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            }
            else if (User.IsInRole("Student"))
            {
                getUserDto.Student = await _studentService.GetIndex(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }

            return View(getUserDto);
        }
    }
}
