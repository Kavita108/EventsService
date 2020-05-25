using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class EventsService : IEventsService
    {
        private readonly string _baseUri;
        private readonly IHttpClient _client;
        public EventsService(IConfiguration config, IHttpClient client)
        {
            _baseUri = $"{config["EventUrl"]}/api/event/";
            _client = client;
        }
        public async Task<Event> GetEventItemsAsync(int page, int size, int? typesFilterApplied, string location)
        {
            var eventItemsUri = ApiPaths.Events.GetAllEventsItems(_baseUri, page, size, typesFilterApplied, location);
            var dataString = await _client.GetStringAsync(eventItemsUri);
            return JsonConvert.DeserializeObject<Event>(dataString);

        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = ApiPaths.Events.GetAllTypes(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("type")
                    }
                );
            }
            return items;
        }
    }
}
