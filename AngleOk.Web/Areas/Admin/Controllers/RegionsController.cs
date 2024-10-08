using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace AngleOk.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[Route("{area}/Regions")]
public class RegionsController(AngleOkContext context) : Controller
{
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View(await context.Regions.Include(i=>i.Country).OrderBy(o => o.Name).ToListAsync());
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        ViewData["CountryId"] = new SelectList(context.Countries, "Id", "Name");
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost("Create")]
    public async Task<IActionResult> Create([Bind("Id,CountryId,Name,EnglishName")] Region region)
    {
        if (ModelState.IsValid)
        {
            try
            {
                region.Id = Guid.NewGuid();
                context.Add(region);
                await context.SaveChangesAsync();
            }

            catch (Exception e)
            {
                return BadRequest("Произошла ошибка:" + e.Message);
            }

        }
        return View(region);
    }

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }
}