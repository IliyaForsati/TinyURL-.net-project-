using Microsoft.AspNetCore.Mvc;
using TinyURL.Domain.Models;

namespace TinyURL.WebPage.Controllers
{
    public class MainController : Controller
    {
        // get request
        public IActionResult Index()
        {
            return View();
        }
        // post request
        [HttpPost]
        public IActionResult Index([Bind("Id,OriginalURL")] Link link)
        {
            return Content($"{link.OriginalURL}");
        }
    }
}
