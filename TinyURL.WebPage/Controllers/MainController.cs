using System;
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
        public async Task<IActionResult> Index(int? id)
        {
            var links = await _linksRepo.GetAllAsync();
            string url = $"{Request.Scheme}://{Request.Host}{Request.Path}";

            if (id != null)
            {
                foreach (var link in links)
                {
                    if (link.ShortCutURLCode == id)
                    {
                        url = $"{link.OriginalURL}";
                        break;
                    }
                }

                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    url = "http://" + url;

                return Redirect(url);
            }
            ViewData["This-Path"] = url;
            return View(new LinkViewModel { Link = null, Links = links});
        }
        // post request
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Id,OriginalURL")] Link link)
        {
            if (!await NumberGenerator.isURLValidAsync(link))
            {
                ViewBag.message = "URL is invalid!";
                return View(new LinkViewModel {Link = link, Links = null});
            }

            // this flag is for avoid creating link with same OriginalURL
            var flag = true;
            var links = await _linksRepo.GetAllAsync();
            foreach (var l in links) 
            {
                if (l.OriginalURL == link.OriginalURL) 
                {
                    link = l;
                    flag = false;
                }
            }

            while (flag)
            {
                int num = NumberGenerator.generateNumber();

                foreach (var l in links) 
                {
                    if (l.ShortCutURLCode == num)
                        continue;
                }

                link.ShortCutURLCode = num;
                await _linksRepo.AddAsync(link);
                break;
            }

            ViewData["This-Path"] = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            return View(new LinkViewModel {Link = link, Links = links});
        }
    }
}
