using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AngleOk.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[Route("{area}/Countries")]
public class CountriesController(AngleOkContext context) : Controller
{
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View(await context.Countries.OrderBy(o => o.Name).ToListAsync());
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost("Create")]
    public async Task<IActionResult> Create([Bind("Id,Name,FullName,EnglishName,Alpha2,Alpha3,Iso")] Country country)
    {
        if (ModelState.IsValid)
        {
            country.Id = Guid.NewGuid();
            context.Add(country);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(country);
    }

    [HttpGet("Edit")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var country = await context.Countries.FindAsync(id);
        if (country == null)
        {
            return NotFound();
        }

        return View(country);
    }

    [HttpPost("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        [Bind("Id,Name,FullName,EnglishName,Alpha2,Alpha3,Iso")] Country country)
    {
        if (id != country.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(country);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(country.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(country);
    }

    [HttpGet("Delete")]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var country = await context.Countries
            .FirstOrDefaultAsync(m => m.Id == id);
        if (country == null)
        {
            return NotFound();
        }

        return View(country);
    }

    [HttpPost("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var country = await context.Countries.FindAsync(id);
        if (country != null)
        {
            context.Countries.Remove(country);
            await context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool CountryExists(Guid id)
    {
        return context.Countries.Any(e => e.Id == id);
    }
}
