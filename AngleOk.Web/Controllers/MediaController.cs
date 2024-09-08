using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Controllers
{
    public class MediaController(AngleOkContext context) : Controller
    {
        [HttpGet("GetImage")]
        public IActionResult GetImage(Guid id)
        {
            var media = context.Medias.Find(id);
            if (media?.Data == null)
            {
                return NotFound();
            }

            return File(media.Data, media.Extension == "png" ? "image/png" : "image/jpeg");
        }
    }
}
