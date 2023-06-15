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
    public class PoliciesStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliciesStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoliciesStatus
        public async Task<IActionResult> Index()
        {
              return _context.PoliciesStatuses != null ? 
                          View(await _context.PoliciesStatuses.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PoliciesStatuses'  is null.");
        }

        // GET: PoliciesStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PoliciesStatuses == null)
            {
                return NotFound();
            }

            var policiesStatus = await _context.PoliciesStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policiesStatus == null)
            {
                return NotFound();
            }

            return View(policiesStatus);
        }

        // GET: PoliciesStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoliciesStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusName")] PoliciesStatus policiesStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policiesStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policiesStatus);
        }

        // GET: PoliciesStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PoliciesStatuses == null)
            {
                return NotFound();
            }

            var policiesStatus = await _context.PoliciesStatuses.FindAsync(id);
            if (policiesStatus == null)
            {
                return NotFound();
            }
            return View(policiesStatus);
        }

        // POST: PoliciesStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusName")] PoliciesStatus policiesStatus)
        {
            if (id != policiesStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policiesStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliciesStatusExists(policiesStatus.Id))
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
            return View(policiesStatus);
        }

        // GET: PoliciesStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PoliciesStatuses == null)
            {
                return NotFound();
            }

            var policiesStatus = await _context.PoliciesStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policiesStatus == null)
            {
                return NotFound();
            }

            return View(policiesStatus);
        }

        // POST: PoliciesStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PoliciesStatuses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PoliciesStatuses'  is null.");
            }
            var policiesStatus = await _context.PoliciesStatuses.FindAsync(id);
            if (policiesStatus != null)
            {
                _context.PoliciesStatuses.Remove(policiesStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliciesStatusExists(int id)
        {
          return (_context.PoliciesStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
