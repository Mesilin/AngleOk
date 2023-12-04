using AngleOk.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    [Route("{area}/Employees")]
    public class EmployeesController : Controller
    {
        private readonly DataManager _dataManager;
        public EmployeesController(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var empl = _dataManager.Employee.GetAll();
            return View(empl);
        }
    }
}
