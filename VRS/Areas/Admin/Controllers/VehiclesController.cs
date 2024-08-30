using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VRS.Areas.Admin.Models;
using VRS.Areas.Admin.Models.VM;
using VRS.Data;

namespace VRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public VehiclesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _appEnvironment = hostEnvironment;
        }

        // GET: Admin/Vehicles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.vehicles.Include(v => v.Brand).Include(v => v.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Vehicles/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.vehicles
                .Include(v => v.Brand)
                .Include(v => v.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Admin/Vehicles/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.brands, "Id", "BrandName");
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "CategoryName");
            return View();
        }

        // POST: Admin/Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleVM vehicleVM)
        {
            if(string.IsNullOrEmpty(vehicleVM.VehicleName))
            {
                ModelState.AddModelError(vehicleVM.VehicleName, "Vehicle Name is Required");

            }
            else if(vehicleVM.VehicleName.Contains('!') || vehicleVM.VehicleName.Contains('@') || vehicleVM.VehicleName.Contains('#') || vehicleVM.VehicleName.Contains('*'))
            {
                ModelState.AddModelError("VehicleName", "Special Characters are not allowed");
            }
                if (ModelState.IsValid)
            {
                try
                {
                    var fileFolder = _appEnvironment.WebRootPath + "\\VehicleImages\\";
                    var fileName = DateTime.Now.ToString("ddMMyyhhmmsstt") + "_" + vehicleVM.ImageFile.FileName;

                    var filePath = fileFolder + fileName;

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        vehicleVM.ImageFile.CopyTo(stream);
                    }

                    // For ASP.NET Core >= 5.0
                    var Userid = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's Id

                    Vehicle vehicle = new Vehicle
                    {
                        VehicleName = vehicleVM.VehicleName,
                        CategoryId = vehicleVM.CategoryId,
                        BrandId = vehicleVM.BrandId,
                        ModelName = vehicleVM.ModelName,
                        ModelYear = vehicleVM.ModelYear,
                        VehicleImage = fileName,
                        Availability = vehicleVM.Availability,
                        Color = vehicleVM.Color,
                        CreatedBy = new Guid(Userid),
                        CreatedTime = DateTime.Now,
                        Price = vehicleVM.Price,
                        RentPerHour = vehicleVM.RentPerHour,
                        Seats = vehicleVM.Seats,
                        UpdatedBy = null,
                        UpdatedTime = null
                    };
                    _context.Add(vehicle);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            ViewData["BrandId"] = new SelectList(_context.brands, "Id", "BrandName", vehicleVM.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "CategoryName", vehicleVM.CategoryId);
            return View(vehicleVM);
        }

        // GET: Admin/Vehicles/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.brands, "Id", "BrandName", vehicle.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "CategoryName", vehicle.CategoryId);
            return View(vehicle);
        }

        // POST: Admin/Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CategoryId,BrandId,VehicleName,ModelName,ModelYear,Color,Seats,Price,RentPerHour,VehicleImage,Availability,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.brands, "Id", "BrandName", vehicle.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "CategoryName", vehicle.CategoryId);
            return View(vehicle);
        }

        // GET: Admin/Vehicles/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.vehicles
                .Include(v => v.Brand)
                .Include(v => v.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Admin/Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var vehicle = await _context.vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.vehicles.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(long id)
        {
            return _context.vehicles.Any(e => e.Id == id);
        }
    }
}
