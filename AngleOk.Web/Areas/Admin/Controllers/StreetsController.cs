using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        return View();
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