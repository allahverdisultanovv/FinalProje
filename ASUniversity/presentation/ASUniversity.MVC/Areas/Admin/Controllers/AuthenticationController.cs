using Microsoft.AspNetCore.Mvc;

namespace ASUniversity.MVC.Areas.Admin.Controllers
{
    public class AuthenticationController : Controller
    {
        //    private readonly UserManager<AppUser> _userManager;
        //    private readonly SignInManager<AppUser> _signInManager;
        //    private readonly AppDbContext _context;

        //    public AuthenticationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        //    {
        //        _userManager = userManager;
        //        _signInManager = signInManager;
        //        _context = context;
        //    }

        //    // GET: /Account/Register
        //    public IActionResult Register()
        //    {
        //        return View();
        //    }

        //    // POST: /Account/Register
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Register(RegisterDto model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            AppUser user = new AppUser
        //            {
        //                Name=model.Name,
        //                UserName = model.Username,
        //                Email = model.Email,

        //            };

        //            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
        //            if (result.Succeeded)
        //            {
        //                if (model.Role == "Student")
        //                {
        //                    var student = new Student
        //                    {
        //                        SpecializationId = model.SpecializationId,
        //                        GroupId = model.GroupId,
        //                        AppUserId = user.Id
        //                    };
        //                    _context.Students.Add(student);
        //                }
        //                else if (model.Role == "Teacher")
        //                {
        //                    var teacher = new Teacher
        //                    {
        //                        Position = model.Position,
        //                        AppUserId = user.Id
        //                    };
        //                    _context.Teachers.Add(teacher);
        //                }

        //                await _context.SaveChangesAsync();

        //                // İstifadəçi uğurla qeydiyyatdan keçdi
        //                return RedirectToAction("Index", "Home");
        //            }

        //            // Qeydiyyat uğursuz olarsa, səhvləri ModelState-ə əlavə et
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }

        //        return View(model);
        //    }
        //}
    }
}
