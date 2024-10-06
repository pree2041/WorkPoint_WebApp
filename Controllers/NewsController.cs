using irs_services.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkPoint_WebApp.Data;
using WorkPoint_WebApp.Entities.Models;
using WorkPoint_WebApp.Service.Contract;
using WorkPoint_WebApp.Shared.DataTransferObjects;
using WorkPoint_WebApp.Shared.Parameters;

namespace WorkPoint_WebApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }


        public async Task<IActionResult> Detail(Guid id)
        {
            var news = await _newsService.GetNewsAsync(id);
            return View(news);
        }

        public async Task<IActionResult> Manage([FromQuery] NewsParameters newsParams)
        {
            var newsList = await _newsService.GetNewsListAsync(newsParams);
            return View(newsList); 
        }

        public async Task<IActionResult> View([FromQuery] NewsParameters newsParams)
        {
            var newsList = await _newsService.GetNewsListAsync(newsParams);
            return View(newsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new NewsDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create(NewsDto newsDto)
        {

            if (ModelState.IsValid)
            {
                await _newsService.CreateNewsAsync(newsDto);
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "There was an error creating the news." });
        }



        public async Task<IActionResult> Edit(Guid id)
        {
            //var news = await _newsService.UpdateNewsAsync(id, newsDto);
            var news = await _newsService.GetNewsAsync(id);
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, NewsDto newsDto)
        {
            if (!ModelState.IsValid)
            {
                return View(newsDto);
            }
            var news = await _newsService.UpdateNewsAsync(id, newsDto);
            return RedirectToAction("Manage"); 
        }


       
    }
}
