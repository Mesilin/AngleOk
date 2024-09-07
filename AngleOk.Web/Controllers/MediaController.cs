using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Controllers
{
    public class MediaController : Controller
    {
        private AngleOkContext _context;
        public MediaController(AngleOkContext context)
        {
            _context = context;
        }
        
        // Метод для получения изображения
        [HttpGet("GetImage")]
        public IActionResult GetImage(Guid id)
        {
            var media = _context.Medias.Find(id);
            if (media == null || media.Data == null)
            {
                return NotFound();
            }

            // Возвращаем изображение с MIME-типом image/jpeg (или другой, в зависимости от формата)
            return File(media.Data, media.Extension == "png" ? "image/png" : "image/jpeg");
        }
    }
}
