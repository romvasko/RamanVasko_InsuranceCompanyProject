using DatabaseSetupProject.Data;
using DatabaseSetupProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSetupProject.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SearchUser(string searchString)
        {

            if (_context.PoliciesOrders == null)
            {
                return Problem("Entity set is null.");
            }

            var searchResult = _context.PoliciesOrders.Include(p => p.Policies).Include(p => p.PoliciesStatus);

            if (!String.IsNullOrEmpty(searchString))
            {
                searchResult = searchResult.Where(s => s.UserId.Contains(searchString)).Include(p => p.Policies).Include(p => p.PoliciesStatus);
            }

            return View(await searchResult.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> SearchByTimeMonth(DateTime searchString)
        {
            DateTime temp = new();
            if (_context.PoliciesOrders == null)
            {
                return Problem("Entity set is null.");
            }

            var searchResult = _context.PoliciesOrders.Include(p => p.Policies).Include(p => p.PoliciesStatus);

            if (!DateTime.Equals(temp, searchString))
            {
                searchResult = searchResult.Where(s => s.PoliciesOrderDateTime.Month == searchString.Month &&
                s.PoliciesOrderDateTime.Year == searchString.Year)
                    .Include(p => p.Policies).Include(p => p.PoliciesStatus);
            }
            return View(await searchResult.ToListAsync());
        }
        
        public async Task<IActionResult> ReportYear(int? id)
        {

            IQueryable<PoliciesOrder> searchResult;
            if (id==null)
            {
                ViewBag.count = _context.PoliciesOrders.Where(p => p.PoliciesOrderDateTime.Year == DateTime.UtcNow.Year).Include(p => p.PoliciesStatus)
                    .Where(p=> p.PoliciesStatus.StatusName == "Paid")
                    .GroupBy(p => p.UserId).Count();
                ViewBag.sum = _context.PoliciesOrders.Where(p => p.PoliciesOrderDateTime.Year == DateTime.UtcNow.Year)
                    .Include(p => p.PoliciesStatus)
                    .Where(p => p.PoliciesStatus.StatusName == "Paid")
                    .SumAsync(p => p.Cost).Result;
                searchResult = _context.PoliciesOrders.Include(p => p.Policies).Include(p => p.PoliciesStatus).Include(p => p.PoliciesStatus)
                    .Where(p => p.PoliciesStatus.StatusName == "Paid")
                    .Where(p => p.PoliciesOrderDateTime.Year == DateTime.UtcNow.Year);
                ViewBag.year = DateTime.UtcNow.Year;
            }
            else
            {
                ViewBag.count = _context.PoliciesOrders.Where(p => p.PoliciesOrderDateTime.Year == id)
                    .Include(p => p.PoliciesStatus)
                    .Where(p => p.PoliciesStatus.StatusName == "Paid")
                    .GroupBy(p => p.UserId).Count();
                ViewBag.sum = _context.PoliciesOrders.Where(p => p.PoliciesOrderDateTime.Year == id)
                    .Include(p => p.PoliciesStatus)
                    .Where(p => p.PoliciesStatus.StatusName == "Paid")
                    .SumAsync(p => p.Cost).Result;
                searchResult = _context.PoliciesOrders.Include(p => p.Policies).Include(p => p.PoliciesStatus)
                    .Where(p => p.PoliciesStatus.StatusName == "Paid").Include(p => p.PoliciesStatus)
                    .Where(p => p.PoliciesOrderDateTime.Year == id);
                ViewBag.year = id;
            }
            return View(await searchResult.ToListAsync());
        }

    }
}
