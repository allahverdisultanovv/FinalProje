using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Application.DTOs.Authentication;
using ASUniversity.Domain.Entities;
using ASUniversity.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASUniversity.Persistence.Implementations.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<bool> Login(LoginDto loginDto)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.EmailOrUsername || u.Email == loginDto.EmailOrUsername);
            if (user == null)
            {
                throw new Exception("UserNot Found");
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.IsPersistence, true);
            if (result.IsLockedOut)
            {
                throw new Exception("Your Account is blocked");
            }
            if (!result.Succeeded)
            {
                throw new Exception("Password is incorrect");
            }
            return true;

        }

        public async Task Register(RegisterDto registerDto, string role)
        {
            AppUser user = new AppUser()
            {
                Name = Char.ToUpper(registerDto.Name[0]) + registerDto.Name.Substring(1).ToLower(),
                UserName = registerDto.Username,
                Surname = Char.ToUpper(registerDto.SurName[0]) + registerDto.SurName.Substring(1).ToLower()

            };
            IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);
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
                    SpecializationId = registerDto.SpecializationId,
                    AdmissionYear = registerDto.AdmissionYear,
                    AppUserId = user.Id,
                    FacultyId = registerDto.FacultyId,
                    GroupId = registerDto.GroupId,
                    Degree = registerDto.Degree
                };

                await _userManager.AddToRoleAsync(user, UserRole.Student.ToString());
            }
            if (role == "Teacher")
            {
                Teacher teacher = new Teacher()
                {
                    AppUserId = user.Id,
                    FacultyId = registerDto.FacultyId,
                    Position = registerDto.Position,
                };
                await _userManager.AddToRoleAsync(user, UserRole.Teacher.ToString());

            }
            await _signInManager.SignInAsync(user, false);
        }
    }
}
