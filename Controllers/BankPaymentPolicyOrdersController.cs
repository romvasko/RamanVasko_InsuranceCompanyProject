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
    [Authorize(Roles = "Manager")]
    public class BankPaymentPolicyOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BankPaymentPolicyOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BankPaymentPolicyOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.bankPaymentPolicyOrders.Include(b => b.BankPayment).Include(b => b.PoliciesOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BankPaymentPolicyOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bankPaymentPolicyOrders == null)
            {
                return NotFound();
            }

            var bankPaymentPolicyOrder = await _context.bankPaymentPolicyOrders
                .Include(b => b.BankPayment)
                .Include(b => b.PoliciesOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankPaymentPolicyOrder == null)
            {
                return NotFound();
            }

            return View(bankPaymentPolicyOrder);
        }

        // GET: BankPaymentPolicyOrders/Create
        public IActionResult Create()
        {
            ViewData["BankPaymentId"] = new SelectList(_context.BankPayments, "Id", "Id");
            ViewData["PoliciesOrderId"] = new SelectList(_context.PoliciesOrders, "Id", "Id");
            return View();
        }

        // POST: BankPaymentPolicyOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoliciesOrderId,BankPaymentId")] BankPaymentPolicyOrder bankPaymentPolicyOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankPaymentPolicyOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankPaymentId"] = new SelectList(_context.BankPayments, "Id", "Id", bankPaymentPolicyOrder.BankPaymentId);
            ViewData["PoliciesOrderId"] = new SelectList(_context.PoliciesOrders, "Id", "Id", bankPaymentPolicyOrder.PoliciesOrderId);
            return View(bankPaymentPolicyOrder);
        }

        // GET: BankPaymentPolicyOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bankPaymentPolicyOrders == null)
            {
                return NotFound();
            }

            var bankPaymentPolicyOrder = await _context.bankPaymentPolicyOrders.FindAsync(id);
            if (bankPaymentPolicyOrder == null)
            {
                return NotFound();
            }
            ViewData["BankPaymentId"] = new SelectList(_context.BankPayments, "Id", "Id", bankPaymentPolicyOrder.BankPaymentId);
            ViewData["PoliciesOrderId"] = new SelectList(_context.PoliciesOrders, "Id", "Id", bankPaymentPolicyOrder.PoliciesOrderId);
            return View(bankPaymentPolicyOrder);
        }

        // POST: BankPaymentPolicyOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoliciesOrderId,BankPaymentId")] BankPaymentPolicyOrder bankPaymentPolicyOrder)
        {
            if (id != bankPaymentPolicyOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankPaymentPolicyOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankPaymentPolicyOrderExists(bankPaymentPolicyOrder.Id))
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
            ViewData["BankPaymentId"] = new SelectList(_context.BankPayments, "Id", "Id", bankPaymentPolicyOrder.BankPaymentId);
            ViewData["PoliciesOrderId"] = new SelectList(_context.PoliciesOrders, "Id", "Id", bankPaymentPolicyOrder.PoliciesOrderId);
            return View(bankPaymentPolicyOrder);
        }

        // GET: BankPaymentPolicyOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bankPaymentPolicyOrders == null)
            {
                return NotFound();
            }

            var bankPaymentPolicyOrder = await _context.bankPaymentPolicyOrders
                .Include(b => b.BankPayment)
                .Include(b => b.PoliciesOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankPaymentPolicyOrder == null)
            {
                return NotFound();
            }

            return View(bankPaymentPolicyOrder);
        }

        // POST: BankPaymentPolicyOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bankPaymentPolicyOrders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.bankPaymentPolicyOrders'  is null.");
            }
            var bankPaymentPolicyOrder = await _context.bankPaymentPolicyOrders.FindAsync(id);
            if (bankPaymentPolicyOrder != null)
            {
                _context.bankPaymentPolicyOrders.Remove(bankPaymentPolicyOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankPaymentPolicyOrderExists(int id)
        {
          return (_context.bankPaymentPolicyOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
