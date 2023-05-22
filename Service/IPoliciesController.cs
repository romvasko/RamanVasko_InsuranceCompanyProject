using DatabaseSetupProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseSetupProject.Service
{
    public interface IPoliciesController
    {
        public Task<IActionResult> Index();
        public Task<IActionResult> Details(int? id);
        public IActionResult Create();
        public Task<IActionResult> Create([Bind("Id,PoliciesName,PoliciesDescription,PoliciesTypeId,BaseCost")] Policies policies);
        public Task<IActionResult> Edit(int? id);
        public Task<IActionResult> Edit(int id, [Bind("Id,PoliciesName,PoliciesDescription,PoliciesTypeId,BaseCost")] Policies policies);
        public Task<IActionResult> Delete(int? id);
        public Task<IActionResult> DeleteConfirmed(int id);
    }
}
