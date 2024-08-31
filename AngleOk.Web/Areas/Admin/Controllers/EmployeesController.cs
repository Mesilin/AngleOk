using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[Route("{area}/Employees")]
public class EmployeesController : Controller
{
    private readonly AngleOkContext _context;
    private readonly DataManager _dataManager;
    public EmployeesController(AngleOkContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GET: Employees
    /// </summary>
    /// <returns></returns>
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Employees.ToListAsync());
    }

    /// <summary>
    /// GET: Employees/Details/5
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("Details")]
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    /// <summary>
    /// GET: Employees/Create
    /// </summary>
    /// <returns></returns>
    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// POST: Employees/Create
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,Patronymic,LastName,Position,Email,PhoneNumber,PublicPhone,IsActive")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            employee.Id = Guid.NewGuid();
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(employee);
    }

    /// <summary>
    /// GET: Employees/Edit/5
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("Edit")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    /// <summary>
    /// POST: Employees/Edit/5
    /// </summary>
    /// <param name="id"></param>
    /// <param name="employee"></param>
    /// <returns></returns>
    [HttpPost("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,
        [Bind("Id,FirstName,Patronymic,LastName,Position,Email,PhoneNumber,PublicPhone,IsActive")] Employee employee)
    {
        if (id != employee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.Id))
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

        return View(employee);
    }

    /// <summary>
    /// GET: Employees/Delete/5
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("Delete")]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    /// <summary>
    /// POST: Employees/Delete/5
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool EmployeeExists(Guid id)
    {
        return _context.Employees.Any(e => e.Id == id);
    }
}
