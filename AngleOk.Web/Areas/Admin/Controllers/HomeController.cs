using AngleOk.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;
        public HomeController(DataManager dataManager) 
        {
            this._dataManager = dataManager;
        }
        [Route("{area}")]
        [HttpGet]
        public IActionResult Index()
        {
            var ads = _dataManager.Advertisements.GetAll();
            return View(ads);
        }
    }
}
