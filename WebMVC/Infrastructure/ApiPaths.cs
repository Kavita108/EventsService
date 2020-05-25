using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPaths
    {
        public static class Events
        {
            public static string GetAllEventsItems(string baseUri, int page, int take, int? type, string location)
            {
                var uri = $"{baseUri}items?pageIndex={page}&pageSize={take}";
                if (type != null)
                {
                    uri += $"&eventTypeId={type}";
                }
                if (!string.IsNullOrEmpty(location))
                {
                    uri += $"&location={location}";
                }

                return uri;
            }

            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }
        }

        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

        
        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        } 
    }
}

