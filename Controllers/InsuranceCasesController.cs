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
    [Authorize(Roles = "Admin, User, Manager")]

    public class InsuranceCasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsuranceCasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InsuranceCases
        public async Task<IActionResult> Index()
        {
              return _context.InsuranceCases != null ? 
                          View(await _context.InsuranceCases.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InsuranceCases'  is null.");
        }

        // GET: InsuranceCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InsuranceCases == null)
            {
                return NotFound();
            }

            var insuranceCase = await _context.InsuranceCases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCase == null)
            {
                return NotFound();
            }

            return View(insuranceCase);
        }

        // GET: InsuranceCases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsuranceCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PhoneNumber,InsuranceCaseDescription,UserId")] InsuranceCase insuranceCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceCase);
                await _context.SaveChangesAsync();
                return RedirectToAction("Response");
            }
            return View(insuranceCase);
        }
        public IActionResult Response()
        {
            ViewBag.Success = "С вами свяжутся менеджеры, ожидайте";
            return View();
        }
        // GET: InsuranceCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InsuranceCases == null)
            {
                return NotFound();
            }

            var insuranceCase = await _context.InsuranceCases.FindAsync(id);
            if (insuranceCase == null)
            {
                return NotFound();
            }
            return View(insuranceCase);
        }

        // POST: InsuranceCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PhoneNumber,InsuranceCaseDescription,UserId")] InsuranceCase insuranceCase)
        {
            if (id != insuranceCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceCaseExists(insuranceCase.Id))
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
            return View(insuranceCase);
        }

        // GET: InsuranceCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InsuranceCases == null)
            {
                return NotFound();
            }

            var insuranceCase = await _context.InsuranceCases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCase == null)
            {
                return NotFound();
            }

            return View(insuranceCase);
        }

        // POST: InsuranceCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InsuranceCases == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InsuranceCases'  is null.");
            }
            var insuranceCase = await _context.InsuranceCases.FindAsync(id);
            if (insuranceCase != null)
            {
                _context.InsuranceCases.Remove(insuranceCase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceCaseExists(int id)
        {
          return (_context.InsuranceCases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
