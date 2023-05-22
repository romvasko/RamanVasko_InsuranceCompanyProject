using DatabaseSetupProject.Data;
using DatabaseSetupProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace DatabaseSetupProject.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;
        Uri baseAddress = new Uri("http://localhost:32771/api");

        public PayController(ApplicationDbContext context)
        { 
            _context = context;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpPost]
        public async Task<IActionResult> PayForPolicy(BankPaymentViewModel _bankPaymentViewModel)
        {
            try
            {
                BankPaymentData bankResponse = new BankPaymentData();
                BankPaymentData temp = new BankPaymentData()
                {
                    id = 0,
                    cardNumber = _bankPaymentViewModel.CardNumber,
                };
                string data = JsonConvert.SerializeObject(temp);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Bank", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    bankResponse = JsonConvert.DeserializeObject<BankPaymentData>(responseData);
                    PoliciesOrder policyOrder = _context.PoliciesOrders.FindAsync(_bankPaymentViewModel.PolicyOrderId).Result;
                    policyOrder.PoliciesStatusId = _context.PoliciesStatuses.Where(p => p.StatusName == "Paid").
                    Select(p => p.Id).
                    FirstOrDefault();
                    _context.Update(policyOrder);
                    await _context.SaveChangesAsync();
                    BankPayment bankPayment = new BankPayment()
                    {
                        Id = bankResponse.id,
                        CardNumber = bankResponse.cardNumber
                    };
                    _context.Add(bankPayment);
                    _context.SaveChanges();
                    await _context.SaveChangesAsync();
                    BankPaymentPolicyOrder model = new BankPaymentPolicyOrder()
                    {
                        BankPaymentId = bankPayment.Id,
                        PoliciesOrderId = policyOrder.Id
                    };
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                return View(new { id = _bankPaymentViewModel.PolicyOrderId });
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PayForPolicy(int? id)
        {
            ViewBag.PolicyOrderId = (int)id;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Success = "Благодарим за оплату";
            return View();
        }
    }
}
