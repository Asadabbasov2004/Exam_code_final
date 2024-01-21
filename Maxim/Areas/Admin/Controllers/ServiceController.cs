using Maxim.Areas.Admin.ViewModels.ServiceVm;
using Maxim.DAL.DbContext;
using Maxim.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Maxim.Areas.Admin.Controllers
{
        [Authorize(Roles = "Admin")]
        public class ServiceController : Controller
        {
            private readonly AppDbContext _context;
            private readonly IWebHostEnvironment _env;

            public ServiceController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }
            public async Task<IActionResult> Index()
            {
                IEnumerable<Service> Services = await _context.Services.ToListAsync();
                return View(Services);
            }
            public async Task<IActionResult> Create()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Create(CreateServiceVm createServiceVm)
            {
                if (!ModelState.IsValid)
                {
                    return View(createServiceVm);
                }
                return RedirectToAction("Index");
            }

        }
    }
