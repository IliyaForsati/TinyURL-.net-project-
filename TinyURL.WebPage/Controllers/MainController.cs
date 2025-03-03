using Microsoft.AspNetCore.Mvc;
using TinyURL.Application.util;
using TinyURL.Domain.Interfaces;
using TinyURL.Domain.Models;

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
        public IActionResult Index()
        {
            return View();
        }
        // post request
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Id,OriginalURL")] Link link)
        {
            while (true)
            {
                int num = NumberGenerator.generateNumber();

                var links = await _linksRepo.GetAllAsync();
                foreach (var l in links) 
                {
                    if (l.ShortCutURLCode == num)
                        continue;
                }

                link.ShortCutURLCode = num;
                await _linksRepo.AddAsync(link);
                break;
            }

            return Redirect("google.com");
        }
    }
}
