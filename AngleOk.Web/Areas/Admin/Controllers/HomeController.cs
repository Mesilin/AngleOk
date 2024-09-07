using AngleOk.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController(DataManager dataManager) : Controller
    {
        [Route("{area}")]
        [HttpGet]
        public IActionResult Index()
        {
            var ads = dataManager.Advertisements.GetAll();
            return View(ads);
        }
    }
}
