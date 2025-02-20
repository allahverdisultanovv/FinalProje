using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Authentication;
using ASUniversity.Domain.Entities;
using ASUniversity.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public AuthenticationService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IStudentService studentService,
            ITeacherService teacherService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _studentService = studentService;
            _teacherService = teacherService;
        }
        public async Task<bool> Login(LoginDto loginDto, ModelStateDictionary ModelState)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.EmailOrUsernameOrFIN || u.Email == loginDto.EmailOrUsernameOrFIN || u.FIN == loginDto.EmailOrUsernameOrFIN);
            if (user == null)
            {
                ModelState.AddModelError("", "User Not found");

            }
            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.IsPersistence, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "User Not found");

            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "User Not found");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;

        }

        public async Task Register(RegisterDto registerDto, string role)
        {
            AppUser user = new AppUser()
            {

                Name = Char.ToUpper(registerDto.Name[0]) + registerDto.Name.Substring(1).ToLower(),
                UserName = GeneretaUserName(registerDto.Name, registerDto.SurName, registerDto.FIN),
                Surname = Char.ToUpper(registerDto.SurName[0]) + registerDto.SurName.Substring(1).ToLower(),
                FIN = registerDto.FIN,
                Email = GeneretaUserName(registerDto.Name, registerDto.SurName, registerDto.FIN).ToLower() + "@as.edu.az"


            };
            string password = registerDto.Name.Substring(0, 1) + "." + registerDto.SurName.Substring(0, 1).ToLower() + registerDto.FIN;
            IdentityResult result = await _userManager.CreateAsync(user, password);
            string text = string.Empty;
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception(error.Description);
                }
            }
            if (role == "Student")
            {
                Student student = new Student()
                {
                    SpecializationId = registerDto.SpecializationId.Value,
                    AdmissionYear = registerDto.AdmissionYear.Value,
                    AppUserId = user.Id,
                    FacultyId = registerDto.FacultyId,
                    GroupId = registerDto.GroupId,
                    Degree = registerDto.Degree.Value
                };
                await _studentService.CreateAsync(student);
                await _userManager.AddToRoleAsync(user, UserRole.Student.ToString());
            }
            if (role == "Teacher")
            {
                Teacher teacher = new Teacher()
                {
                    AppUserId = user.Id,
                    FacultyId = registerDto.FacultyId,
                    Position = registerDto.Position.Value,
                };
                await _teacherService.CreateAsync(teacher);
                await _userManager.AddToRoleAsync(user, UserRole.Teacher.ToString());

            }
            await _signInManager.SignInAsync(user, false);
        }
        public async Task CreateRole()
        {
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole() { Name = role.ToString() });
                }
            }
        }
        private string GeneretaUserName(string name, string surname, string fin)
        {
            string username = name + surname.Substring(0, 1).ToUpper() + fin.Substring(3);
            return username;
        }
    }
}
