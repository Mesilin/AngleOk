using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        AngleOkContext db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public HomeController(AngleOkContext db/*, ITimeService timeServ*/)
        {
            this.db = db;
            //timeService = timeServ;
        }
        //readonly ITimeService timeService;

        //public string Index()
        //{
        //    string name = Request.Query["name"];
        //    string age = Request.Query["age"];
        //    return $"Name: {name}  Age: {age}";
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public string Index()=>"Hello METANIT.COM";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() => View();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpPost]
        public string Index(string username) => $"User Name: {username}";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult About() => View();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeService"></param>
        /// <returns></returns>
        public IActionResult Index2([FromServices] ITimeService timeService)
        {
            //ITimeService? timeService = HttpContext.RequestServices.GetService<ITimeService>();
            //return timeService?.Time ?? "Undefined";


            Person tom = new Person() { PersonId=Guid.NewGuid(), FirstName="Tom", LastName="qwe",PhoneNumber= timeService?.Time ?? "Undefined" };

            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // не учитываем регистр
                WriteIndented = true                // отступы для красоты
            };
            return Json(tom, jsonOptions);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllUsers()
        {
            return View(await db.Persons.ToListAsync());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Person user)
        {
            try
            {
                db.Persons.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return await AllUsers();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult License()
        {
            return View();
        }
    }
}
