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
    public class CarPolicyOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarPolicyOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarPolicyOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CarPolicyOrder.Include(c => c.CarPolicyCondition).Include(c => c.PoliciesOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CarPolicyOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarPolicyOrder == null)
            {
                return NotFound();
            }

            var carPolicyOrder = await _context.CarPolicyOrder
                .Include(c => c.CarPolicyCondition)
                .Include(c => c.PoliciesOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carPolicyOrder == null)
            {
                return NotFound();
            }

            return View(carPolicyOrder);
        }

        // GET: CarPolicyOrders/Create
        public IActionResult Create()
        {
            ViewData["CarPolicyConditionId"] = new SelectList(_context.CarPolicyConditions, "id", "id");
            ViewData["PoliciesOrderId"] = new SelectList(_context.PoliciesOrders, "Id", "Id");
            return View();
        }

        // POST: CarPolicyOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoliciesOrderId,CarPolicyConditionId")] CarPolicyOrder carPolicyOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carPolicyOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarPolicyConditionId"] = new SelectList(_context.CarPolicyConditions, "id", "id", carPolicyOrder.CarPolicyConditionId);
            ViewData["PoliciesOrderId"] = new SelectList(_context.PoliciesOrders, "Id", "Id", carPolicyOrder.PoliciesOrderId);
            return View(carPolicyOrder);
        }

        // GET: CarPolicyOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarPolicyOrder == null)
            {
                return NotFound();
            }

            var carPolicyOrder = await _context.CarPolicyOrder.FindAsync(id);
            if (carPolicyOrder == null)
            {
                return NotFound();
            }
            ViewData["CarPolicyConditionId"] = new SelectList(_context.CarPolicyConditions, "id", "id", carPolicyOrder.CarPolicyConditionId);
            ViewData["PoliciesOrderId"] = new SelectList(_context.PoliciesOrders, "Id", "Id", carPolicyOrder.PoliciesOrderId);
            return View(carPolicyOrder);
        }

        // POST: CarPolicyOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoliciesOrderId,CarPolicyConditionId")] CarPolicyOrder carPolicyOrder)
        {
            if (id != carPolicyOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carPolicyOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarPolicyOrderExists(carPolicyOrder.Id))
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
            ViewData["CarPolicyConditionId"] = new SelectList(_context.CarPolicyConditions, "id", "id", carPolicyOrder.CarPolicyConditionId);
            ViewData["PoliciesOrderId"] = new SelectList(_context.PoliciesOrders, "Id", "Id", carPolicyOrder.PoliciesOrderId);
            return View(carPolicyOrder);
        }

        // GET: CarPolicyOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarPolicyOrder == null)
            {
                return NotFound();
            }

            var carPolicyOrder = await _context.CarPolicyOrder
                .Include(c => c.CarPolicyCondition)
                .Include(c => c.PoliciesOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carPolicyOrder == null)
            {
                return NotFound();
            }

            return View(carPolicyOrder);
        }

        // POST: CarPolicyOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarPolicyOrder == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CarPolicyOrder'  is null.");
            }
            var carPolicyOrder = await _context.CarPolicyOrder.FindAsync(id);
            if (carPolicyOrder != null)
            {
                _context.CarPolicyOrder.Remove(carPolicyOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarPolicyOrderExists(int id)
        {
          return (_context.CarPolicyOrder?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
