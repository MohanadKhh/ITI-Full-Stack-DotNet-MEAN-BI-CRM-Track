using ECommerce.BLL;
using ECommerce.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager
                                , UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var applicationUser = new ApplicationUser
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
            };

            try
            {
                IdentityResult result = await _userManager.CreateAsync(applicationUser, registerVM.Password);
                if (!result.Succeeded)
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                    return View(registerVM);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(applicationUser, "User");
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            ApplicationUser? user = await _userManager.FindByEmailAsync(loginVM.Eamil);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user,
                loginVM.Password,
                loginVM.RemeberMe,
                lockoutOnFailure: true
                );

            if (result.Succeeded)
                return RedirectToAction("Index", "Product");

            if (result.IsLockedOut)
                ModelState.AddModelError("", "Account locked, Try again later");

            ModelState.AddModelError("", "Invalid Email or Password");
            return View(loginVM);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
