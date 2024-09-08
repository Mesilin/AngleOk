using AngleOk.Web.Repositories.Abstract;
//using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Controllers
{
    public class HomeController(DataManager dataManager) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
            //return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }

        [HttpGet]
        public IActionResult Advertisements()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageAdvertisements"));
        }
    }
}
