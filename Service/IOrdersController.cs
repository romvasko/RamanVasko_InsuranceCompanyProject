using DatabaseSetupProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseSetupProject.Service
{
    public interface IOrdersController
    {
        Task<IActionResult> Index();
        Task<IActionResult> GetPolicie(int? id);
        Task<IActionResult> Auto(CarPolicyViewModel _carPolicyViewModel);
        Task<IActionResult> AutoOrderCreate(CarPolicyViewModel _carPolicyViewModel);

    }
}
