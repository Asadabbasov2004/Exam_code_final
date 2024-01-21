using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maxim.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("Admin")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
