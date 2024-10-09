using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
namespace AngleOk.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[Route("{area}/Streets")]
public class StreetsController(AngleOkContext context) : Controller
{
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View(await context.Streets.Include(i=>i.City).OrderBy(o=>o.Name).ToListAsync());
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        ViewData["CityId"] = new SelectList(context.Cities, "Id", "Name");
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost("Create")]
    public async Task<IActionResult> Create([Bind("Id,CityId,Name")] Street street)
    {
        if (ModelState.IsValid)
        {
            street.Id = Guid.NewGuid();
            context.Add(street);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(street);
    }
    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }
}