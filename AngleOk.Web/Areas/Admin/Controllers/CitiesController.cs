using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace AngleOk.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[Route("{area}/Cities")]
public class CitiesController(AngleOkContext context) : Controller
{
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View(await context.Cities.Include(i=>i.Region).ThenInclude(i=>i.Country).OrderBy(o => o.Name).ToListAsync());
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        ViewData["CountryId"] = new SelectList(context.Countries, "Id", "Name");
        ViewData["RegionId"] = new SelectList(context.Regions, "Id", "Name");
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost("Create")]
    public async Task<IActionResult> Create(
        [Bind("Id,RegionId,Name,Population")]
        City city)
    {
        if (ModelState.IsValid)
        {
            try
            {
                city.Id = Guid.NewGuid();
                context.Add(city);
                await context.SaveChangesAsync();
            }

            catch (Exception e)
            {
                return BadRequest("Произошла ошибка:" + e.Message);
            }

        }
        return View(city);
    }


    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }


    [HttpGet("GetRegionsByCountry")]
    public JsonResult GetRegionsByCountry(Guid countryId)
    {
        var regions = context.Regions
            .Where(r => r.CountryId == countryId)
            .Select(r => new { id = r.Id, name = r.Name })
            .ToList();
        return Json(regions);
    }
}