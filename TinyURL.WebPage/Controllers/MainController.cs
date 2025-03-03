using Microsoft.AspNetCore.Mvc;
using TinyURL.Application.util;
using TinyURL.Domain.Interfaces;
using TinyURL.Domain.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TinyURL.WebPage.Controllers
{
    public class MainController : Controller
    {
        private readonly IRepository<Link> _linksRepo;
        public MainController(IRepository<Link> linkRepo)
        {
            _linksRepo = linkRepo;
        }

        // get request
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                return Redirect("https://google.com");
            }
            return View();
        }
        // post request
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Id,OriginalURL")] Link link)
        {
            // this flag is for avoid creating link with same OriginalURL
            var flag = true;
            var links = await _linksRepo.GetAllAsync();
            foreach (var l in links) 
            {
                if (l.OriginalURL == link.OriginalURL)
                    flag = false;
            }

            while (true)
            {
                int num = NumberGenerator.generateNumber();

                foreach (var l in links) 
                {
                    if (l.ShortCutURLCode == num)
                        continue;
                }

                link.ShortCutURLCode = num;
                if (flag) await _linksRepo.AddAsync(link);
                break;
            }

            ViewData["This-Path"] = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            return View(link);
            //return Content($"your shortcut is <http://localhost:5284/{link.ShortCutURLCode}>");
        }
    }
}
