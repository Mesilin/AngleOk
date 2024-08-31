using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Controllers.Mvc
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        AngleOkContext db;
        public HomeController(AngleOkContext db, DataManager dataManager)
        {
            this.dataManager = dataManager;
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //return RedirectToAction("Index", "Home", new { Area = "Admin" });
			return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
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
