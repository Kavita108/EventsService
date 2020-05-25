using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventsService _service;
        public EventController(IEventsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? typesFilterApplied, string location)
        {
            var itemsOnPage = 10;
            var events = await _service.GetEventItemsAsync(page ?? 0, itemsOnPage, typesFilterApplied, location);
            var vm = new EventIndexViewModel
            {
                EventItems = events.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = events.Count,
                    TotalPages = (int)Math.Ceiling((decimal)events.Count / itemsOnPage)
                },
                Types = await _service.GetTypesAsync()
            };  
            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }
    }
}