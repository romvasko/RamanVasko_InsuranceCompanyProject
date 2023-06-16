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
    [Authorize(Roles = "Admin, Manger")]
    public class PoliciesOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliciesOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoliciesOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PoliciesOrders.Include(p => p.Policies).Include(p => p.PoliciesStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PoliciesOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PoliciesOrders == null)
            {
                return NotFound();
            }

            var policiesOrder = await _context.PoliciesOrders
                .Include(p => p.Policies)
                .Include(p => p.PoliciesStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policiesOrder == null)
            {
                return NotFound();
            }

            return View(policiesOrder);
        }

        // GET: PoliciesOrders/Create
        public IActionResult Create()
        {
            ViewData["PoliciesId"] = new SelectList(_context.Policies, "Id", "PoliceName");
            ViewData["PoliciesStatusId"] = new SelectList(_context.PoliciesStatuses, "Id", "StatusName");
            return View();
        }

        // POST: PoliciesOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoliciesId,UserId,PoliciesStatusId,PoliciesOrderDateTime,Cost")] PoliciesOrder policiesOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policiesOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoliciesId"] = new SelectList(_context.Policies, "Id", "Id", policiesOrder.PoliciesId);
            ViewData["PoliciesStatusId"] = new SelectList(_context.PoliciesStatuses, "Id", "Id", policiesOrder.PoliciesStatusId);
            return View(policiesOrder);
        }

        // GET: PoliciesOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PoliciesOrders == null)
            {
                return NotFound();
            }

            var policiesOrder = await _context.PoliciesOrders.FindAsync(id);
            if (policiesOrder == null)
            {
                return NotFound();
            }
            ViewData["PoliciesId"] = new SelectList(_context.Policies, "Id", "Id", policiesOrder.PoliciesId);
            ViewData["PoliciesStatusId"] = new SelectList(_context.PoliciesStatuses, "Id", "Id", policiesOrder.PoliciesStatusId);
            return View(policiesOrder);
        }

        // POST: PoliciesOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoliciesId,UserId,PoliciesStatusId,PoliciesOrderDateTime,Cost")] PoliciesOrder policiesOrder)
        {
            if (id != policiesOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policiesOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliciesOrderExists(policiesOrder.Id))
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
            ViewData["PoliciesId"] = new SelectList(_context.Policies, "Id", "Id", policiesOrder.PoliciesId);
            ViewData["PoliciesStatusId"] = new SelectList(_context.PoliciesStatuses, "Id", "Id", policiesOrder.PoliciesStatusId);
            return View(policiesOrder);
        }

        // GET: PoliciesOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PoliciesOrders == null)
            {
                return NotFound();
            }

            var policiesOrder = await _context.PoliciesOrders
                .Include(p => p.Policies)
                .Include(p => p.PoliciesStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policiesOrder == null)
            {
                return NotFound();
            }

            return View(policiesOrder);
        }

        // POST: PoliciesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PoliciesOrders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PoliciesOrders'  is null.");
            }
            var policiesOrder = await _context.PoliciesOrders.FindAsync(id);
            if (policiesOrder != null)
            {
                _context.PoliciesOrders.Remove(policiesOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliciesOrderExists(int id)
        {
          return (_context.PoliciesOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
