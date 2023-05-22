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
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Manager")]
    public class PoliciesTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliciesTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoliciesTypes
        public async Task<IActionResult> Index()
        {
              return _context.PoliciesTypes != null ? 
                          View(await _context.PoliciesTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PoliciesTypes'  is null.");
        }

        // GET: PoliciesTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PoliciesTypes == null)
            {
                return NotFound();
            }

            var policiesType = await _context.PoliciesTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policiesType == null)
            {
                return NotFound();
            }

            return View(policiesType);
        }

        // GET: PoliciesTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoliciesTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoliciesTypeName")] PoliciesType policiesType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policiesType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policiesType);
        }

        // GET: PoliciesTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PoliciesTypes == null)
            {
                return NotFound();
            }

            var policiesType = await _context.PoliciesTypes.FindAsync(id);
            if (policiesType == null)
            {
                return NotFound();
            }
            return View(policiesType);
        }

        // POST: PoliciesTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoliciesTypeName")] PoliciesType policiesType)
        {
            if (id != policiesType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policiesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliciesTypeExists(policiesType.Id))
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
            return View(policiesType);
        }

        // GET: PoliciesTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PoliciesTypes == null)
            {
                return NotFound();
            }

            var policiesType = await _context.PoliciesTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policiesType == null)
            {
                return NotFound();
            }

            return View(policiesType);
        }

        // POST: PoliciesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PoliciesTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PoliciesTypes'  is null.");
            }
            var policiesType = await _context.PoliciesTypes.FindAsync(id);
            if (policiesType != null)
            {
                _context.PoliciesTypes.Remove(policiesType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliciesTypeExists(int id)
        {
          return (_context.PoliciesTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
