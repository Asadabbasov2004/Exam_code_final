using Maxim.Areas.Admin.ViewModels.ServiceVm;
using Maxim.DAL.DbContext;
using Maxim.Helper;
using Maxim.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Data;

namespace Maxim.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ServiceController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Service> services = await _db.Services.ToListAsync();
            return View(services);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceVm vm)
        {
            if (!ModelState.IsValid) return View(vm);
            //if (!vm.Image.CheckType("image"))
            //{
            //    ModelState.AddModelError("Image", "Only image format");
            //    return View(vm);
            //}
            if (!vm.Image.CheckLength(3))
            {
                ModelState.AddModelError("Image", "Max length - 3mb");
                return View(vm);
            }
            Service service = new Service()
            {
                Title = vm.Title,
               Description = vm.Description,
               ImgUrl = vm.Image.Upload(_env.WebRootPath, @"\Upload\Images\"),
            };
            await _db.Services.AddAsync(service);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0) return BadRequest();
            Service service = await _db.Services.Where(f => f.Id == id).FirstOrDefaultAsync();
            if (service is null) return BadRequest();
            UpdateServiceVm vm = new UpdateServiceVm()
            {
                Id = id,
                Title = service.Title,
               Description= service.Description,
                ImgUrl = service.ImgUrl
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceVm vm)
        {
            Service service = await _db.Services.Where(x=>x.Id == x.Id).FirstOrDefaultAsync();
            if (service is null) return BadRequest();
            if (!ModelState.IsValid) { return View(vm); }
            if (vm.Image is not null)
            {
                //if (!vm.Image.CheckType("image"))
                //{
                //    ModelState.AddModelError("Image", "Only image format");
                //    return View(vm);
                //}
                if (!vm.Image.CheckLength(3))
                {
                    ModelState.AddModelError("Image", "Max length - 3mb");
                    return View(vm);
                }
                service.ImgUrl = vm.Image.Upload(_env.WebRootPath, @"\Upload\Images\");
            }
            //else
            //{
            //    service.ImgUrl = vm.Image.Upload(_env.WebRootPath, @"\Upload\Images\");
            //}
            service.Title = vm.Title;
            service.Description = vm.Description;
            _db.Update(service);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            Service fruit = await _db.Services.Where(x=>x.Id==id).FirstOrDefaultAsync();
            if (fruit is not null) _db.Services.Remove(fruit);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}




