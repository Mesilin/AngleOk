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
        public async Task<IActionResult> Index()
        {
            var p = await db.Persons.ToListAsync();
            p = p.Where(q => q.PhoneNumber.Contains("-")).ToList();
            return View(p);
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
