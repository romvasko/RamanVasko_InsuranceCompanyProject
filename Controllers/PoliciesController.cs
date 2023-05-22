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
using DatabaseSetupProject.Service;

namespace DatabaseSetupProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Manager")]
    public class PoliciesController : Controller, IPoliciesController
    {
        private readonly ApplicationDbContext _context;

        public PoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Policies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Policies.Include(p => p.PoliciesType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Policies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Policies == null)
            {
                return NotFound();
            }

            var policies = await _context.Policies
                .Include(p => p.PoliciesType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policies == null)
            {
                return NotFound();
            }

            return View(policies);
        }

        // GET: Policies/Create
        public IActionResult Create()
        {
            ViewData["PoliciesTypeId"] = new SelectList(_context.PoliciesTypes, "Id", "PoliciesTypeName");
            return View();
        }

        // POST: Policies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoliciesName,PoliciesDescription,PoliciesTypeId,BaseCost")] Policies policies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoliciesTypeId"] = new SelectList(_context.PoliciesTypes, "Id", "PoliciesTypeName", policies.PoliciesTypeId);
            return View(policies);
        }

        // GET: Policies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Policies == null)
            {
                return NotFound();
            }

            var policies = await _context.Policies.FindAsync(id);
            if (policies == null)
            {
                return NotFound();
            }
            ViewData["PoliciesTypeId"] = new SelectList(_context.PoliciesTypes, "Id", "PoliciesTypeName", policies.PoliciesTypeId);
            return View(policies);
        }

        // POST: Policies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoliciesName,PoliciesDescription,PoliciesTypeId,BaseCost")] Policies policies)
        {
            if (id != policies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliciesExists(policies.Id))
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
            ViewData["PoliciesTypeId"] = new SelectList(_context.PoliciesTypes, "Id", "PoliciesTypeName", policies.PoliciesTypeId);
            return View(policies);
        }

        // GET: Policies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Policies == null)
            {
                return NotFound();
            }

            var policies = await _context.Policies
                .Include(p => p.PoliciesType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policies == null)
            {
                return NotFound();
            }

            return View(policies);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Policies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Policies'  is null.");
            }
            var policies = await _context.Policies.FindAsync(id);
            if (policies != null)
            {
                _context.Policies.Remove(policies);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliciesExists(int id)
        {
          return (_context.Policies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
