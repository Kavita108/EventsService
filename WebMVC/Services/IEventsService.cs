using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IEventsService
    {
        Task<Event> GetEventItemsAsync(int page, int size, int? typesFilterApplied, string location);
        Task<IEnumerable<SelectListItem>> GetTypesAsync();
    }
}
