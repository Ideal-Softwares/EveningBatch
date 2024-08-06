using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VRS.Areas.Admin.Models;
using VRS.Areas.Admin.Models.VM;
using VRS.Data;

namespace VRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Brands
        public async Task<IActionResult> Index()
        {
            return View(await _context.brands.Select(b => new BrandVM { BrandName = b.BrandName, Id = b.Id }).ToListAsync());
        }

        // GET: Admin/Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Admin/Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandName")] BrandVM brand)
        {
            if (ModelState.IsValid)
            {
                // For ASP.NET Core >= 5.0
                var Userid = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's Id

                Brand b = new Brand
                {
                    Id = brand.Id,
                    BrandName = brand.BrandName,
                    CreatedBy = new Guid(Userid) ,
                    CreatedTime = DateTime.Now,
                    UpdatedBy = Guid.Empty,
                    UpdatedTime = null,
                    Status = false
                };
                _context.Add(b);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Admin/Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            BrandVM brandVM = new BrandVM
            {
                BrandName = brand.BrandName,
                Id = brand.Id
            };
            return View(brandVM);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,BrandName")] BrandVM brand)
        {
            if (brand.Id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // For ASP.NET Core >= 5.0
                    var Userid = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's Id

                    var b = await _context.brands.FindAsync(brand.Id);
                    if (b == null)
                    {
                        return NotFound();
                    }
                    b.BrandName = brand.BrandName;
                    b.UpdatedBy = new Guid(Userid);
                    b.UpdatedTime = DateTime.Now;


                    _context.Update(b);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Id))
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
            return View(brand);
        }

        // GET: Admin/Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Admin/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _context.brands.FindAsync(id);
            if (brand != null)
            {
                _context.brands.Remove(brand);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return _context.brands.Any(e => e.Id == id);
        }
    }
}
