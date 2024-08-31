using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AngleOk.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[Route("{area}/Clients")]
public class ClientsController : Controller
{
    private readonly AngleOkContext _context;

    public ClientsController(AngleOkContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GET: Clients
    /// </summary>
    /// <returns></returns>
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Clients.ToListAsync());
    }

    // GET: Clients/Details/5
    [HttpGet("Details")]
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var client = await _context.Clients
            .FirstOrDefaultAsync(m => m.Id == id);
        if (client == null)
        {
            return NotFound();
        }

        return View(client);
    }

    // GET: Clients/Create
    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: Clients/Create
    [ValidateAntiForgeryToken]
    [HttpPost("Create")]
    public async Task<IActionResult> Create([Bind("Id,FirstName,Patronymic,LastName,Email,PhoneNumber")] Client client)
    {
        if (ModelState.IsValid)
        {
            client.Id = Guid.NewGuid();
            _context.Add(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(client);
    }

	// GET: Clients/Edit/5
    [HttpGet("Edit")]
	public async Task<IActionResult> Edit(Guid? id)
	{
		if (id == null)
		{
			return NotFound();
		}

		var client = await _context.Clients.FindAsync(id);
		if (client == null)
		{
			return NotFound();
		}

		return View(client);
	}

	// POST: Clients/Edit/5
    [HttpPost("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        [Bind("Id,FirstName,Patronymic,LastName,Email,PhoneNumber")] Client client)
    {
        if (id != client.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(client);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(client.Id))
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

        return View(client);
    }

    // GET: Clients/Delete/5
    [HttpGet("Delete")]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var client = await _context.Clients
            .FirstOrDefaultAsync(m => m.Id == id);
        if (client == null)
        {
            return NotFound();
        }

        return View(client);
    }

    // POST: Clients/Delete/5
    [HttpPost("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool ClientExists(Guid id)
    {
        return _context.Clients.Any(e => e.Id == id);
    }
}