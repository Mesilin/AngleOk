using AngleOk.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Controllers.Mvc
{
    public class AdvertisementsController:Controller
    {
        private readonly DataManager dataManager;
        public AdvertisementsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Advertisements.GetAdvertisementById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageAdvertisements");
            return View(dataManager.Advertisements.GetAll());
        }
    }
}
