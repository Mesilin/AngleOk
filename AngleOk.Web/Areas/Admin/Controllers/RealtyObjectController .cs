using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	[Route("{area}/RealtyObject")]
	public class RealtyObjectController(AngleOkContext context) : Controller
	{
		/// <summary>
		/// GET: RealtyObject
		/// </summary>
		/// <returns></returns>
		[HttpGet("Index")]
		public async Task<IActionResult> Index()
		{
			var realtyObjects = await context.RealtyObjects
				.Include(i => i.RealtyObjectKind)
				.Include(i => i.Street)
				.ThenInclude(i => i!.City)
				.ThenInclude(i => i!.Region)
				.ThenInclude(i => i.Country)
				.ToListAsync();
			return View(realtyObjects);
		}

		/// <summary>
		/// GET: RealtyObject/Details/5
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

			var realtyObject = await context.RealtyObjects
				.Include(i => i.RealtyObjectKind)
				.Include(i => i.Street)
				.ThenInclude(i => i.City)
				.ThenInclude(i => i!.Region)
				.ThenInclude(i => i.Country)
				.Include(r => r.MediaMaterials)
				.FirstOrDefaultAsync(m => m.Id == id);

			if (realtyObject == null)
			{
				return NotFound();
			}

			return View(realtyObject);
		}

		/// <summary>
		/// GET: RealtyObject/Create
		/// </summary>
		/// <returns></returns>
		[HttpGet("Create")]
		public IActionResult Create()
		{
			ViewData["RealtyObjectKindId"] = new SelectList(context.RealtyObjectKinds, "Id", "RealtyObjectKindName");
			ViewData["CityId"] = new SelectList(context.Cities, "Id", "Name");
			return View();
        }

		private readonly List<string> _allowedMediaFiles = new() { ".png", ".jpg", ".jpeg" };

		[ValidateAntiForgeryToken]
		[HttpPost("Create")]
		public async Task<IActionResult> Create(
			[Bind("Id,CadastralNumber,CityId,StreetId,PostalCode,House,HouseLetter,Building,Apartment,Latitude,Longitude,Description,RealtyObjectKindId")]
			RealtyObject realtyObject,
			List<IFormFile> MediaFiles)
		{
			if (ModelState.IsValid)
			{
				try
				{
					realtyObject.Id = Guid.NewGuid();

					// Если есть загруженные файлы
					if (MediaFiles.Count > 0)
					{
						foreach (var file in MediaFiles)
						{
							var ext = Path.GetExtension(file.FileName);
							var name = Path.GetFileName(file.FileName);

							if (file.Length is > 0 and <= 20000000 && _allowedMediaFiles.Contains(ext.ToLower()))
							{
								using (var memoryStream = new MemoryStream())
								{
									await file.CopyToAsync(memoryStream);
									var media = new Media
									{
										Id = Guid.NewGuid(),
										Data = memoryStream.ToArray(),
										FileName = name,
										Extension = ext,
										//Description = "Uploaded file",
										RealtyObjectId = realtyObject.Id,
										IsTitle = name.ToLower().Contains("title")
									};
									context.Add(media);
								}
							}
						}
					}

					context.Add(realtyObject);
					await context.SaveChangesAsync();
				}

				catch (Exception e)
				{
					return BadRequest("Произошла ошибка:" + e.Message);
				}

			}
			return View(realtyObject);
		}

		/// <summary>
        /// GET: RealtyObject/Edit/5
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

            var realtyObject = await context.RealtyObjects
	            .Include(r => r.MediaMaterials)
	            .Include(i=>i.Street)
	            .ThenInclude(i=>i!.City)
	            .ThenInclude(i=>i!.Region)
	            .ThenInclude(i=>i.Country)
	            .FirstOrDefaultAsync(m => m.Id == id);
            if (realtyObject == null)
            {
                return NotFound();
            }

            if (realtyObject.Street != null) 
                realtyObject.CityId = realtyObject.Street.CityId;

            ViewData["RealtyObjectKindId"] = new SelectList(context.RealtyObjectKinds, "Id", "RealtyObjectKindName", realtyObject.RealtyObjectKindId);
            ViewData["CityId"] = new SelectList(context.Cities, "Id", "Name");
            ViewData["StreetId"] = new SelectList(context.Streets.Where(w=>w.CityId== realtyObject.CityId), "Id", "Name");

			return View(realtyObject);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
			[Bind("Id,CadastralNumber,CityId,StreetId,PostalCode,House,HouseLetter,Building,Apartment,Latitude,Longitude,Description,RealtyObjectKindId")]
			RealtyObject realtyObject, List<IFormFile> MediaFiles)
        {
            if (id != realtyObject.Id)
            {
                return NotFound();
            }

			if (ModelState.IsValid)
            {
                try
                {
					var existingMedia = await GetMediaByObjectId(realtyObject.Id);

					if (MediaFiles.Count > 0)
                    {
						foreach (var file in MediaFiles)
                        {
	                        var ext = Path.GetExtension(file.FileName);
	                        var name = Path.GetFileName(file.FileName);
	                        if (file.Length is > 0 and <= 20000000 && _allowedMediaFiles.Contains(ext.ToLower()))
	                        {
		                        using (var memoryStream = new MemoryStream())
		                        {
			                        await file.CopyToAsync(memoryStream);
			                        var media = new Media
			                        {
				                        Id = Guid.NewGuid(),
				                        Data = memoryStream.ToArray(),
				                        FileName = name,
				                        Extension = ext,
				                        RealtyObjectId = realtyObject.Id,
                                        IsTitle = name.ToLower().Contains("title")
									};
			                        context.Add(media);
		                        }
	                        }
                        }

                    }

					context.Update(realtyObject);
                    await context.SaveChangesAsync();
                    context.Medias.RemoveRange(existingMedia);
                    await context.SaveChangesAsync();
				}
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealtyObjectExists(realtyObject.Id))
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
	        
	        ViewData["RealtyObjectKindId"] = new SelectList(context.RealtyObjectKinds, "Id", "RealtyObjectKindName", realtyObject.RealtyObjectKindId);
			ViewData["CityId"] = new SelectList(context.Cities, "Id", "Name");
            ViewData["StreetId"] = new SelectList(context.Streets.Where(w=>w.CityId== realtyObject.CityId), "Id", "Name");
			return View(realtyObject);
        }

        private async Task<List<Media>> GetMediaByObjectId(Guid objectId)
        {
            return await context.Medias.Where(w => w.RealtyObjectId == objectId).ToListAsync();
        }


        /// <summary>
        /// GET: RealtyObject/Delete/5
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

            var realtyObject = await context.RealtyObjects
	            .Include(i=>i.RealtyObjectKind)
	            .FirstOrDefaultAsync(m => m.Id == id);
            if (realtyObject == null)
            {
                return NotFound();
            }

            return View(realtyObject);
        }

        /// <summary>
        /// POST: RealtyObject/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
	        var realtyObject = await context.RealtyObjects.Include(i => i.MediaMaterials).FirstOrDefaultAsync(m => m.Id == id);

            if (realtyObject == null) 
                return RedirectToAction(nameof(Index));
            
            var existingMedia = await GetMediaByObjectId(realtyObject.Id);
            context.Medias.RemoveRange(existingMedia);
			context.RealtyObjects.Remove(realtyObject);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetStreetsByCity(Guid cityId)
        {
            var streets = context.Streets
                .Where(r => r.CityId == cityId)
                .Select(r => new { id = r.Id, name = r.Name })
                .ToList();
            return Json(streets);
        }

        private bool RealtyObjectExists(Guid id)
        {
            return context.RealtyObjects.Any(e => e.Id == id);
        }


    }
}
