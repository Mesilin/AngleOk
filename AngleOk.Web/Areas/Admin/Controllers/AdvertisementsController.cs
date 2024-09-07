using AngleOk.Web.Models;
using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [Route("{area}/Advertisements")]
    public class AdvertisementsController(AngleOkContext context, DataManager dataManager) : Controller
    {
        /// <summary>
		/// GET: Advertisement by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Advertisements.GetAdvertisementById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageAdvertisements");
            return View(dataManager.Advertisements.GetAll());
        }

		/// <summary>
		/// GET: Advertisements/Create
		/// </summary>
		/// <returns></returns>
		[HttpGet("Create")]
		public IActionResult Create()
        {
            // Подготовка данных для выбора существующих объектов недвижимости
            var viewModel = new AdvertisementCreateViewModel
            {
                RealtyObjects = context.RealtyObjects.ToList(), 
                Clients = context.Clients.ToList(),
                Managers = context.Employees.ToList(),
                DealTypes = context.DealTypes.ToList()
            };

            return View(viewModel);
        }

		/// <summary>
		/// POST: Advertisements/Create
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdvertisementCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
	            var realtyObject = context.RealtyObjects.FirstOrDefault(r => r.Id == viewModel.SelectedRealtyObjectId);

                if (realtyObject != null)
                {
                    var advertisement = new Advertisement
                    {
                        Id = Guid.NewGuid(),
                        DealTypeId = viewModel.SelectedDealTypeId,
                        RealtyObjectId = realtyObject.Id,
                        TargetPrice = viewModel.TargetPrice,
                        MinPrice = viewModel.MinPrice,
                        MaxPrice = viewModel.MaxPrice,
                        ManagerId = viewModel.SelectedManagerId,
                        IsActive = viewModel.IsActive,
                        Description = viewModel.Description,
                        ShortDescription = viewModel.ShortDescription,
                        ClientId = viewModel.SelectedClientId,
                    };

                    context.Advertisements.Add(advertisement);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }

            // Перезагрузка данных в случае ошибки
            viewModel.RealtyObjects = context.RealtyObjects.ToList();
            viewModel.Clients = context.Clients.ToList();
            viewModel.Managers = context.Employees.ToList();
            viewModel.DealTypes = context.DealTypes.ToList();

			return View(viewModel);
        }

        /// <summary>
        /// Метод для отображения списка объявлений
        /// </summary>
        /// <returns></returns>
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
	        var ads = await context.Advertisements
				.Include(a => a.RealtyObject)
					.ThenInclude(i=>i!.RealtyObjectKind)
				.Include(a => a.Manager)
				.Include(a => a.Client)
				.Include(a => a.DealType)
				.OrderBy(o=>o.DealType!.DealTypeName)
				.ToListAsync();
	        return View(ads);
        }

		/// <summary>
		/// GET: Advertisements/Details/5
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

			var adv = await context.Advertisements
				.Include(i => i.RealtyObject).ThenInclude(i=>i!.RealtyObjectKind)
				.Include(i => i.RealtyObject)
				.Include(i => i.Client)
				.Include(i => i.DealType)
				.Include(i => i.Manager)
				.FirstOrDefaultAsync(m => m.Id == id);

			if (adv == null)
			{
				return NotFound();
			}

			return View(adv);
		}

        /// <summary>
		/// GET: Advertisements/Edit/5
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
            var adv = await context.Advertisements.FirstOrDefaultAsync(m => m.Id == id);

            if (adv == null)
            {
                return NotFound();
            }

            ViewData["RealtyObjectId"] = new SelectList(context.RealtyObjects, "Id", "Address", adv.RealtyObjectId);

            var clientList = context.Clients.Select(x => new
            {
                x.Id,
                FullName = x.FirstName + " " + x.LastName
            });

            ViewData["ClientId"] = new SelectList(clientList, "Id", "FullName", adv.ClientId);
            ViewData["DealTypeId"] = new SelectList(context.DealTypes, "Id", "DealTypeName", adv.DealTypeId);
            var managerList = context.Employees.Select(x => new
            {
                x.Id,
                FullName = x.FirstName + " " + x.LastName
            });
            ViewData["ManagerId"] = new SelectList(managerList, "Id", "FullName", adv.ManagerId); 

            return View(adv);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, 
            [Bind("Id,ClientId,DealTypeId,RealtyObjectId,ManagerId,Description,ShortDescription,TargetPrice,MinPrice,MaxPrice,IsActive")] Advertisement adv)
        {
            if (id != adv.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(adv);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvExists(adv.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception e)
                {
                    return BadRequest("Произошла ошибка:" + e.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errs=ModelState.Values.SelectMany(s => s.Errors).ToList();
            }
            return View(adv);
        }

        private bool AdvExists(Guid id)
        {
            return context.Advertisements.Any(e => e.Id == id);
        }









        /// <summary>
        /// GET: Advertisements/Delete/5
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

            var ad = await context.Advertisements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

		/// <summary>
		/// POST: Advertisements/Delete/5
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		//[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var adv = await context.Advertisements.FindAsync(id);
            if (adv != null) 
	            context.Advertisements.Remove(adv);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}