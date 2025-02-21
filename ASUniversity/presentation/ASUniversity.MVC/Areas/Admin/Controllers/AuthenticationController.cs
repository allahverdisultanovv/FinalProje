using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Authentication;
using ASUniversity.Domain.Enums;
using ASUniversity.Persistence.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASUniversity.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _service;
        private readonly IFacultyService _facultyService;
        private readonly IGroupService _groupService;
        private readonly ISpecializationService _specializationService;

        public AuthenticationController(IAuthenticationService service, IFacultyService facultyService, IGroupService groupService, ISpecializationService specializationService)
        {
            _service = service;
            _facultyService = facultyService;
            _groupService = groupService;
            _specializationService = specializationService;
        }
        public async Task<IActionResult> Register()
        {
            RegisterDto registerDto = new RegisterDto()
            {
                Positions = Enum.GetValues(typeof(Position))
                        .Cast<Position>()
                        .Select(p => new SelectListItem
                        {
                            Value = ((int)p).ToString(),
                            Text = EnumHelper.GetEnumDescription(p)
                        })
                        .ToList(),
                Degrees = Enum.GetValues(typeof(Degree))
                        .Cast<Degree>()
                        .Select(d => new SelectListItem
                        {
                            Value = ((int)d).ToString(),
                            Text = EnumHelper.GetEnumDescription(d)
                        })
                        .ToList(),


                Faculties = await _facultyService.GetAllSelectAsync(),
                Groups = await _groupService.GetAllSelectAsync(),
            };
            return View(registerDto);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            if (registerDto.Degree is not null)
            {
                await _service.Register(registerDto, "Student");

            }
            else
            {
                await _service.Register(registerDto, "Teacher");
            }



            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            bool result = await _service.Login(loginDto, ModelState);
            if (!result)
                ModelState.AddModelError(string.Empty, "Username or password is incorrect");
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> CreateRoles()
        {
            await _service.CreateRole();
            return RedirectToAction("Index", "Home");
        }
    }
}
