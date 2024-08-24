using AngleOk.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [Route("{area}/RealtyObjects")]
    public class RealtyObjectsController : Controller
    {
        private readonly DataManager _dataManager;
        public RealtyObjectsController(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var objects = _dataManager.RealtyObject.GetAll();
            return View(objects);
        }
    }
}
