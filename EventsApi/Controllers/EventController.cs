using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsApi.Data;
using EventsApi.Domain;
using EventsApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventsContext _context;
        private readonly IConfiguration _config;
        public EventController(EventsContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //This service looks for searched events wrt multiple parameter values
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
             [FromQuery]string location = "",
             [FromQuery]int eventTypeId = -1,
             [FromQuery]int pageIndex = 0,
             [FromQuery]int pageSize = 6)
        {

            /* code for following cases:
                 - Both location and eventTypeId input provided.
                 - Or only location provided
                 - Or only eventTypeId provided
                 - or Both location and eventTypeId not provided.
            */

            List<EventItem> items;
            List<EventItem> totalItems;

            if (string.IsNullOrEmpty(location) && eventTypeId == -1)
            {
                totalItems = await _context.EventItems.ToListAsync();
            }
            else if(string.IsNullOrEmpty(location) && eventTypeId != -1)
            {
                totalItems = await _context.EventItems
                         .Where(i => i.EventTypeId == eventTypeId).ToListAsync();
            }
            else if(!string.IsNullOrEmpty(location) && eventTypeId == -1)
            {
                totalItems = await _context.EventItems
                          .Where(i => i.Location == location).ToListAsync();
            }
            else
            {
                totalItems = await _context.EventItems
                         .Where(i => i.Location == location && i.EventTypeId == eventTypeId)
                          .ToListAsync();
            }

            items = totalItems
                          .Skip(pageIndex * pageSize)
                           .Take(pageSize).ToList();

            var itemsCount = totalItems.Count();
            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items,
            };

            return Ok(model);

        }

        //This service looks for particular event details
        [HttpGet]
        [Route("item")]
        public async Task<IActionResult> Item(
            [FromQuery]int eventId)
        {
            var item = await _context.EventItems
                         .Where(i => i.Id == eventId)
                          .ToListAsync();
          
            var items = ChangePictureUrl(item);
            return Ok(items[0]);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(
                c => c.PictureUrl =
                    c.PictureUrl.Replace("http://baseurltobereplaced",
                    _config["ExternalEventBaseUrl"])
                );
            return items;
        }
    }
}