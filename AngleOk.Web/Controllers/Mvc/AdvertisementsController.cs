using AngleOk.Web.Models;
using AngleOk.Web.Repositories.Abstract;
using Castle.Components.DictionaryAdapter;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AngleOk.Web.Controllers.Mvc
{
    public class AdvertisementsController:Controller
    {
        private readonly AngleOkContext _context;
        private readonly DataManager _dataManager;
        public AdvertisementsController(AngleOkContext context, DataManager dataManager)
        {
            _context = context;
            _dataManager = dataManager;
        }

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
                return View("Show", _dataManager.Advertisements.GetAdvertisementById(id));
            }

            ViewBag.TextField = _dataManager.TextFields.GetTextFieldByCodeWord("PageAdvertisements");
            return View(_dataManager.Advertisements.GetAll());
        }
        
        /// <summary>
        /// GET: Advertisements/Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            // Подготовка данных для выбора существующих объектов недвижимости
            var viewModel = new AdvertisementCreateViewModel
            {
                RealtyObjects = _context.RealtyObjects.ToList()
            };

            return View(viewModel);
        }

		/// <summary>
		/// POST: Advertisements/Create
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdvertisementCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Создание или получение объекта недвижимости
                RealtyObject realtyObject;
                if (viewModel.NewRealtyObject)
                {
                    realtyObject = new RealtyObject
                    {
                        Id = Guid.NewGuid(),
                        RealtyObjectKind = viewModel.RealtyObjectKind,
                        CadastralNumber = viewModel.CadastralNumber,
                        Address = viewModel.Address,
                        Latitude = viewModel.Latitude,
                        Longitude = viewModel.Longitude,
                        Description = viewModel.Description,
                        //RealtyObjectOwners = new EditableList<RealtyObjectOwner>(){}

                    };


                    _context.RealtyObjects.Add(realtyObject);
                }
                else
                {
                    realtyObject = _context.RealtyObjects
                        .FirstOrDefault(r => r.Id == viewModel.SelectedRealtyObjectId);
                }

                if (realtyObject != null)
                {
                    var advertisement = new Advertisement
                    {
                        Id = Guid.NewGuid(),
                        ClientId = viewModel.ClientId,
                        DealType = viewModel.DealType,
                        RealtyObjectId = realtyObject.Id,
                        TargetPrice = viewModel.TargetPrice,
                        MinPrice = viewModel.MinPrice,
                        MaxPrice = viewModel.MaxPrice,
                        ManagerId = viewModel.ManagerId,
                        IsActive = viewModel.IsActive,
                        Description = viewModel.Description,
                        ShortDescription = viewModel.ShortDescription,
                        Client = null,
                        Manager =null 
                    };

                    _context.Advertisements.Add(advertisement);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }

            // Перезагрузка данных в случае ошибки
            viewModel.RealtyObjects = _context.RealtyObjects.ToList();

            return View(viewModel);
        }

        /// <summary>
        /// Метод для отображения списка объявлений
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var advertisements = _context.Advertisements
                .Include(a => a.RealtyObject)
                .Include(a => a.Manager)
                .Include(a => a.Client)
;//                .ToList();
            return View(advertisements);
        }

    }
}
