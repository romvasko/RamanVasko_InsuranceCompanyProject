using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseSetupProject.Data;
using DatabaseSetupProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace DatabaseSetupProject.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class CarPolicyConditionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarPolicyConditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarPolicyConditions
        public async Task<IActionResult> Index()
        {
              return _context.CarPolicyConditions != null ? 
                          View(await _context.CarPolicyConditions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CarPolicyConditions'  is null.");
        }

        // GET: CarPolicyConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarPolicyConditions == null)
            {
                return NotFound();
            }

            var carPolicyCondition = await _context.CarPolicyConditions
                .FirstOrDefaultAsync(m => m.id == id);
            if (carPolicyCondition == null)
            {
                return NotFound();
            }

            return View(carPolicyCondition);
        }

        // GET: CarPolicyConditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarPolicyConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,IsHadAccident,DriverAge")] CarPolicyCondition carPolicyCondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carPolicyCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carPolicyCondition);
        }

        // GET: CarPolicyConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarPolicyConditions == null)
            {
                return NotFound();
            }

            var carPolicyCondition = await _context.CarPolicyConditions.FindAsync(id);
            if (carPolicyCondition == null)
            {
                return NotFound();
            }
            return View(carPolicyCondition);
        }

        // POST: CarPolicyConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,IsHadAccident,DriverAge")] CarPolicyCondition carPolicyCondition)
        {
            if (id != carPolicyCondition.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carPolicyCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarPolicyConditionExists(carPolicyCondition.id))
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
            return View(carPolicyCondition);
        }

        // GET: CarPolicyConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarPolicyConditions == null)
            {
                return NotFound();
            }

            var carPolicyCondition = await _context.CarPolicyConditions
                .FirstOrDefaultAsync(m => m.id == id);
            if (carPolicyCondition == null)
            {
                return NotFound();
            }

            return View(carPolicyCondition);
        }

        // POST: CarPolicyConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarPolicyConditions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CarPolicyConditions'  is null.");
            }
            var carPolicyCondition = await _context.CarPolicyConditions.FindAsync(id);
            if (carPolicyCondition != null)
            {
                _context.CarPolicyConditions.Remove(carPolicyCondition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarPolicyConditionExists(int id)
        {
          return (_context.CarPolicyConditions?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
