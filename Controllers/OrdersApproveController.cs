using DatabaseSetupProject.Data;
using DatabaseSetupProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSetupProject.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class OrdersApproveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersApproveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoliciesOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PoliciesOrders.Include(p => p.Policies).Include(p => p.PoliciesStatus)
                .Where(p=>p.PoliciesStatus.StatusName == "InProced");
            return View(await applicationDbContext.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int? id)
        {
            if (id == null || _context.Policies == null)
            {
                return NotFound();
            }

            var model = _context.PoliciesOrders.FindAsync(id).Result;
            if(model == null)
            {
                return NotFound();
            }
            model.PoliciesStatusId = _context.PoliciesStatuses.Where(p => p.StatusName == "Accepted").
                Select(p => p.Id).
                FirstOrDefault();
            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(int? id)
        {
            if (id == null || _context.Policies == null)
            {
                return NotFound();
            }

            var model = _context.PoliciesOrders.FindAsync(id).Result;
            if (model == null)
            {
                return NotFound();
            }
            model.PoliciesStatusId = _context.PoliciesStatuses.Where(p => p.StatusName == "Declined").
                Select(p => p.Id).
                FirstOrDefault();
            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
