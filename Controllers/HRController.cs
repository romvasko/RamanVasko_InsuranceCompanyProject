using Microsoft.AspNetCore.Mvc;

namespace DatabaseSetupProject.Controllers
{
    public class HRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
