using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VRMS.Data;
using VRMS.Data.Entities;
using VRMS.Models;

namespace VRMS.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public VehicleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<VehicleViewModel> list = new List<VehicleViewModel>();
            list = _dbContext.vheicles.Select(v => new VehicleViewModel
            {
                Name = v.Name,
                Description = v.Description,
                Color = v.Color,
                Id = v.Id,
                Model = v.Model
            }).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleViewModel vehicleView)
        {
            if (ModelState.IsValid)
            {
                Vheicle vheicle = new Vheicle
                {
                    Name = vehicleView.Name,
                    Description = vehicleView.Description,
                    Model = vehicleView.Model,
                    Color = vehicleView.Color,
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now,

                };

                using (var dbContext = _dbContext)
                {
                    dbContext.Add(vheicle);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            return View(GetVehicle(Id));
        }

        [HttpPost]
        public IActionResult Edit(VehicleViewModel vehicleView)
        {
            if (ModelState.IsValid)
            {
                Vheicle vheicle = _dbContext.vheicles.FirstOrDefault(v => v.Id == vehicleView.Id);
                if (vheicle != null)
                {
                    vheicle.Name = vehicleView.Name;
                    vheicle.Description = vehicleView.Description;
                    vheicle.Model = vehicleView.Model;
                    vheicle.Color = vehicleView.Color;
                    vheicle.updatedBy = "System";
                    vheicle.updatedDate = DateTime.Now;
                }

                using (var dbContext = _dbContext)
                {
                    dbContext.Update(vheicle);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(long Id)
        {
            return View(GetVehicle(Id));
        }

        public IActionResult Delete(long Id)
        {
            return View(GetVehicle(Id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(long Id)
        {
            var vehicle = _dbContext.vheicles.Find(Id);
            if (vehicle != null)
            {
                _dbContext.vheicles.Remove(vehicle);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public VehicleViewModel GetVehicle(long Id)
        {
            var VehicleViewModel = _dbContext.vheicles.Select(v => new VehicleViewModel
            {
                Name = v.Name,
                Description = v.Description,
                Color = v.Color,
                Id = v.Id,
                Model = v.Model
            }).FirstOrDefault(v => v.Id == Id);

            return VehicleViewModel;
        }
    }
}
