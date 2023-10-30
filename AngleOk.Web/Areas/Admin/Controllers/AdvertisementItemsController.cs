using AngleOk.Web.Repositories.Abstract;
using AngleOk.Web.Services;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("{area}/{controller}")]
    public class AdvertisementItemsController : Controller
    {
        private AngleOkContext db;
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public AdvertisementItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AngleOkContext db)
        {
            this.db = db;
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        //[Route("{controller}/Edit")]
        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Advertisement() : dataManager.Advertisements.GetAdvertisementById(id);
            return View(entity);
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save(Advertisement model)
        {
            //todo разобраться. вероятно есть цикличесткая зависимость между медиа и адв
            var newMedia = new Media();
            newMedia.MediaId = Guid.NewGuid();
            newMedia.Description = "Титульное фото";
            newMedia.RealtyObjectId = Guid.Parse("1beb19c2-afbd-47ea-b5d9-1376ab3c3918");
            newMedia.Extension = "png";
            newMedia.IsTitleImage = true;
            newMedia.FileName = "asdasdfas";

            var adv = db.Advertisements.Find(model.AdvertisementId);
            adv.ShortDescription = model.ShortDescription;
            dataManager.Advertisements.SaveAdvertisement(adv);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());


            /*
            //var ro = db.RealtyObjects.Find(newMedia.RealtyObjectId);
            var ro = db.RealtyObjects
                .Where(w=>w.RealtyObjectId==newMedia.RealtyObjectId)
                .Include(i=>i.RealtyObjectType)
                .First();

            model.ContractId=Guid.Parse("afa46d7d-9403-4915-aedf-f55b9ea1dfdc");
            model.ManagerId=Guid.Parse("30349c9a-5a8e-486f-9ebd-dd6e8ffe71a3");
            newMedia.RealtyObject = ro;

            ro.MediaMaterials= new List<Media> { newMedia };
            model.RealtyObject = ro;


            ModelState.ClearValidationState(nameof(model));
            if (!TryValidateModel(model, nameof(model)))
            {
                return View("Edit", model);
            }
            dataManager.Advertisements.SaveAdvertisement(model);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            */
        }

        [HttpPost]
        public IActionResult Edit(Advertisement model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    //model.TitleImageId = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.Advertisements.SaveAdvertisement(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Advertisements.DeleteAdvertisement(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
