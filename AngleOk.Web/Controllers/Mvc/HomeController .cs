using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Controllers.Mvc
{
    public class HomeController : Controller
    {
        AngleOkContext db;
        public HomeController(AngleOkContext db)
        {
            this.db = db;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            return View(await db.Persons.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person user)
        {
            db.Persons.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
