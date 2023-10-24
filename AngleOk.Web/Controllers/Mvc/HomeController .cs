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
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }

        //public async Task<IActionResult> Index()
        //{
        //    var p = await db.Persons.ToListAsync();
        //    p = p.Where(q => q.PhoneNumber.Contains("-")).ToList();
        //    return View(p);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Person user)
        //{
        //    db.Persons.Add(user);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
