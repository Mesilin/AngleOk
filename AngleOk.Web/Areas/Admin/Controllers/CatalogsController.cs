using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[Route("{area}/Catalogs")]
public class CatalogsController(AngleOkContext context) : Controller
{
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View();
    }
}