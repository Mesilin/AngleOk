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
                .Include(r => r.TitleImage)
                .Include(i => i.RealtyObjectKind)
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
                .Include(r => r.TitleImage)
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
            return View();
        }

        private readonly List<string> _allowedMediaFiles = new() { "png", "jpg", "jpeg" };

        [ValidateAntiForgeryToken]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(
            [Bind("Id,CadastralNumber,Address,Latitude,Longitude,Description,RealtyObjectKindId")]
            RealtyObject realtyObject,
            List<IFormFile> mediaFiles)
        {
            {
                realtyObject.Id = Guid.NewGuid();

                // Если есть загруженные файлы
                if (mediaFiles != null && mediaFiles.Count > 0)
                {
                    Guid id = default;
                    realtyObject.TitleImageId = null;

                    foreach (var file in mediaFiles)
                    {
                        var ext = Path.GetExtension(file.FileName);
                        var name = Path.GetFileName(file.FileName);

                        if (file.Length is > 0 and <= 20000000 && _allowedMediaFiles.Contains(ext.ToLower()))
                        {
                            id = Guid.NewGuid();
                            if (name.ToLower().Contains("title"))
                            {
                                realtyObject.TitleImageId = id;
                            }
                            using (var memoryStream = new MemoryStream())
                            {
                                await file.CopyToAsync(memoryStream);
                                var media = new Media
                                {
                                    Id = id,
                                    Data = memoryStream.ToArray(),
                                    FileName = name,
                                    Extension = ext,
                                    Description = "Uploaded file",
                                    RealtyObjectId = realtyObject.Id
                                };
                                context.Add(media);
                            }
                        }
                    }

                    if (realtyObject.TitleImageId == null && id != default)
                        realtyObject.TitleImageId = id;
                }

                context.Add(realtyObject);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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

            var realtyObject = await context.RealtyObjects.Include(r => r.MediaMaterials).FirstOrDefaultAsync(m => m.Id == id);
            if (realtyObject == null)
            {
                return NotFound();
            }
            ViewData["RealtyObjectKindId"] = new SelectList(context.RealtyObjectKinds, "Id", "RealtyObjectKindName", realtyObject.RealtyObjectKindId);

            return View(realtyObject);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CadastralNumber,Address,Latitude,Longitude,Description,RealtyObjectKindId")] RealtyObject realtyObject, List<IFormFile> mediaFiles)
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
                    context.Medias.RemoveRange(existingMedia);

                    if (mediaFiles.Count > 0)
                    {
                        foreach (var file in mediaFiles)
                        {
                            if (file.Length > 0)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    await file.CopyToAsync(memoryStream);
                                    var media = new Media
                                    {
                                        Id = Guid.NewGuid(),
                                        Data = memoryStream.ToArray(),
                                        FileName = Path.GetFileName(file.FileName),
                                        Extension = Path.GetExtension(file.FileName),
                                        Description = "Uploaded file",
                                        RealtyObjectId = realtyObject.Id
                                    };
                                    context.Medias.Add(media);
                                }
                            }
                        }
                    }

                    context.Update(realtyObject);
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
            var realtyObject = await context.RealtyObjects.FindAsync(id);
            if (realtyObject == null) 
                return RedirectToAction(nameof(Index));
            context.RealtyObjects.Remove(realtyObject);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool RealtyObjectExists(Guid id)
        {
            return context.RealtyObjects.Any(e => e.Id == id);
        }
    }
}
