using Maxim.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Maxim.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager )
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
