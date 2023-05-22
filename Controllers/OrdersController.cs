using DatabaseSetupProject.Data;
using DatabaseSetupProject.Models;
using DatabaseSetupProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace DatabaseSetupProject.Controllers
{
    [Authorize]
    public class OrdersController : Controller, IOrdersController
    {
        private readonly ApplicationDbContext _context;
        
        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        // GET: Policies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Policies.Include(p => p.PoliciesType);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> GetPolicie(int? id)
        {
            if (_context.Policies.Where(p => p.Id == (int)id).Select(p => p.PoliciesName).FirstOrDefault() == "Автомобильное")
            {
                return RedirectToAction("Auto", new CarPolicyViewModel { PoliciesId = (int)id });
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Auto(CarPolicyViewModel _carPolicyViewModel)
        {
            return RedirectToAction("AutoOrderCreate", new CarPolicyViewModel
            {
                PoliciesId = _carPolicyViewModel.PoliciesId,
                PoliciesStatusId = _context.PoliciesStatuses.Where(p => p.StatusName == "InProced").
       Select(p => p.Id).
       FirstOrDefault(),
                UserId = User.Identity.Name,
                Cost = _context.Policies.Where(p => p.Id == _carPolicyViewModel.PoliciesId).Select(p => p.BaseCost).FirstOrDefault()
            });
        }
        
        public async Task<IActionResult> AutoOrderCreate(CarPolicyViewModel _carPolicyViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    CarPolicyCondition model1 = new CarPolicyCondition
                    {
                        DriverAge = _carPolicyViewModel.DriverAge,
                        IsHadAccident = _carPolicyViewModel.IsHadAccident
                    };
                    PoliciesOrder model2 = new PoliciesOrder
                    {
                        Cost = _carPolicyViewModel.Cost,
                        PoliciesOrderDateTime = DateTime.UtcNow,
                        UserId = _carPolicyViewModel.UserId,
                        PoliciesStatusId = _carPolicyViewModel.PoliciesStatusId,
                        PoliciesId = _carPolicyViewModel.PoliciesId
                    };
                    CarPolicyOrder model = new();
                    _context.Add(model1);
                    _context.Add(model2);
                    await _context.SaveChangesAsync();
                    model.CarPolicyConditionId = model1.id;
                    model.PoliciesOrderId = model2.Id;
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ViewBag.Error = ex.Message;
                }
            }
            return View(_carPolicyViewModel);

        }
    }
}
