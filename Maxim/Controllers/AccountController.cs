using Maxim.Helper;
using Maxim.Models.Entities;
using Maxim.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Maxim.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            AppUser user = new AppUser()
            {
                Name=vm.Name,
                Surname=vm.Surname,
                UserName=vm.UserName,
                Email=vm.Email,
            };
            var res =await _userManager.CreateAsync(user, vm.Password);
            if (!res.Succeeded)
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(vm); 
            }
            await _userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
            return RedirectToAction(nameof(Login));
        } 
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var res = await _userManager.FindByEmailAsync(vm.UserNameOrEmail) ?? await _userManager.FindByNameAsync(vm.UserNameOrEmail);
            if (res == null)
            {
                ModelState.AddModelError("", "Username/gmail Or password is wrong");
                return View(vm);
            }
            var user =await _signInManager.PasswordSignInAsync(res, vm.Password, true, false);
            if (!user.Succeeded)
            {
                ModelState.AddModelError("", "Username/gmail Or password is wrong");
                return View(vm);
            }

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateRole()
        {
            foreach (var item in Enum.GetValues(typeof(UserRole)))
            {
                if (await _roleManager.FindByIdAsync(item.ToString()) == null)
                {
                   await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = item.ToString(),
                    });
                };
            }
            return RedirectToAction("Index","Home");
        }

    }
}
