using EventsApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApi.Data
{
    public static class EventSeed
    {
        public static void Seed(EventsContext context)
        {
            context.Database.Migrate();
            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetPreConfiguredEventTypes());
                context.SaveChanges();
            }

            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetPreConfiguredEventItems());
                context.SaveChanges();
            }

        }

        private static IEnumerable<EventItem> GetPreConfiguredEventItems()
        {
            /*return new List<EventItem>
            {
                new EventItem { EventTypeId = 1, Description = "we sip, paint, and have some in the house fun!", Name = "Sip&Paint:PaintNite", Venue = "Online", Location = "Redmond", Price = 25M, StartTime = new DateTime(2020, 04, 15, 12, 30, 0), EndTime = new DateTime(2020, 04, 15, 13, 30, 0), PictureUrl = "http://baseurltobereplaced/api/pic/1" },
                new EventItem { EventTypeId = 2, Description = "It is rich,creamy,cottage cheese dish prepared using butter", Name = "IndianCookingLesson:Paneer Butter Masala", Venue = "Online", Location = "Bothell", Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/2" },
                new EventItem { EventTypeId = 3, Description = "Let's listen some music & have some in the house fun!", Name = "ShankarMahadevanLIVE Online", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 15, 12, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 45M, PictureUrl = "http://baseurltobereplaced/api/pic/3" },
                new EventItem { EventTypeId = 4, Description = "Let's Bake,we thought we'd bring the Bakehouse to you, virtually!", Name = "Bakehouse LIVE: Homemade Cinnamon Rolls", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 04, 15, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 14, 30, 0), Price = 55M, PictureUrl = "http://baseurltobereplaced/api/pic/4" },
                new EventItem { EventTypeId = 5, Description = "Breathe, Meditate & Be Happy! Learn the power of your own breath!", Name = "Beyond Breath Online - An Introduction to the Happiness Program", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 15, 06, 30, 0) , EndTime = new DateTime(2020, 04, 17, 13, 30, 0), Price = 75M, PictureUrl = "http://baseurltobereplaced/api/pic/5" },
                new EventItem { EventTypeId = 6, Description = "Let take the workout PowerHour fitness format for busy people.", Name = "Virtual Zumba Blast", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 13, 10, 30, 0) , EndTime = new DateTime(2020, 04, 13, 11, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/6" },
                new EventItem { EventTypeId = 7, Description = "fun day for the kids, with lots of props and activities to do!", Name = "Kids Photography", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 04, 13, 10, 30, 0) , EndTime = new DateTime(2020, 04, 15, 11, 30, 0), Price = 25M, PictureUrl = "http://baseurltobereplaced/api/pic/7" },
                new EventItem { EventTypeId = 8, Description = "Learn how to get started with writing stories from your imagination!", Name = "Childrens Story Writing Workshops", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 5M, PictureUrl = "http://baseurltobereplaced/api/pic/8" },
                new EventItem { EventTypeId = 9, Description = "keep your kids creative and engaged.Minimal Supplies and Maximum Fun!", Name = "Online Kids Craft & Activities", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 13, 11, 30, 0) , EndTime = new DateTime(2020, 04, 13, 12, 30, 0), Price = 10M, PictureUrl = "http://baseurltobereplaced/api/pic/9" },
                new EventItem { EventTypeId = 1, Description = "Dance to all your favorite Bollywood and other regional hits all night long!", Name = "BollyWood Fusion Boat Party", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 05, 23, 03, 30, 0) , EndTime = new DateTime(2020, 05, 23, 05, 30, 0), Price = 100M, PictureUrl = "http://baseurltobereplaced/api/pic/10" },
                new EventItem { EventTypeId = 2, Description = "This 45-minute heart-pumping dance workout will keep you burning those calories.", Name = "Virtual Bollywood Cardio", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 13, 10, 30, 0) , EndTime = new DateTime(2020, 04, 13, 11, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/11" },
                new EventItem { EventTypeId = 3, Description = "Let's have family friendly daytime celebration!", Name = "Holi Hai : Color Festival", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/12" },
                new EventItem { EventTypeId = 4, Description = "Come join for some fun with Bhangra dance classes! !", Name = "Learn Bhangra: Bringing BHANGRA to everyone", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 20, 06, 30, 0) , EndTime = new DateTime(2020, 04, 20, 06, 30, 0), Price = 20M, PictureUrl = "http://baseurltobereplaced/api/pic/13" },
                new EventItem { EventTypeId = 4, Description = "Come join us have some fun in Run!", Name = "5K Run", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 05, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/14" },
                new EventItem { EventTypeId = 4, Description = "Come join us !", Name = "Senior Get Together", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 5M, PictureUrl = "http://baseurltobereplaced/api/pic/15" },
            };*/
            return new List<EventItem>
            {
                new EventItem { EventTypeId = 1, Description = "we sip, paint, and have some in the house fun!", Name = "Sip & Paint", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 20, 13, 30, 0) , EndTime = new DateTime(2020, 04, 20, 14, 30, 0), Price = 25M, PictureUrl = "http://baseurltobereplaced/api/pic/1" },
                new EventItem { EventTypeId = 2, Description = "It is rich,creamy,cottage cheese dish prepared using butter", Name = "Indian Cooking Lesson", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 18, 12, 30, 0) , EndTime = new DateTime(2020, 04, 18, 13, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/2" },
                new EventItem { EventTypeId = 3, Description = "Let's listen some music & have some in the house fun!", Name = "Shankar Mahadevan Live Online", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 15, 12, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 45M, PictureUrl = "http://baseurltobereplaced/api/pic/3" },
                new EventItem { EventTypeId = 4, Description = "Let's Bake,we thought we'd bring the Bakehouse to you, virtually!", Name = "Bakehouse LIVE: Homemade Cinnamon Rolls", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 04, 15, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 14, 30, 0), Price = 55M, PictureUrl = "http://baseurltobereplaced/api/pic/4" },
                new EventItem { EventTypeId = 5, Description = "Breathe, Meditate & Be Happy! Learn the power of your own breath!", Name = "Beyond Breath Online - An Introduction to the Happiness Program", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 15, 06, 30, 0) , EndTime = new DateTime(2020, 04, 17, 13, 30, 0), Price = 75M, PictureUrl = "http://baseurltobereplaced/api/pic/5" },
                new EventItem { EventTypeId = 1, Description = "Let take the workout PowerHour fitness format for busy people.", Name = "Virtual Zumba Blast", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 13, 10, 30, 0) , EndTime = new DateTime(2020, 04, 13, 11, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/6" },
                new EventItem { EventTypeId = 2, Description = "fun day for the kids, with lots of props and activities to do!", Name = "Kids Photography", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 04, 13, 10, 30, 0) , EndTime = new DateTime(2020, 04, 15, 11, 30, 0), Price = 25M, PictureUrl = "http://baseurltobereplaced/api/pic/7" },
                new EventItem { EventTypeId = 3, Description = "Learn how to get started with writing stories from your imagination!", Name = "Childrens Story Writing Workshops", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 5M, PictureUrl = "http://baseurltobereplaced/api/pic/8" },
                new EventItem { EventTypeId = 5, Description = "keep your kids creative and engaged.Minimal Supplies and Maximum Fun!", Name = "Online Kids Craft & Activities", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 13, 11, 30, 0) , EndTime = new DateTime(2020, 04, 13, 12, 30, 0), Price = 10M, PictureUrl = "http://baseurltobereplaced/api/pic/9" },
                new EventItem { EventTypeId = 1, Description = "Dance to all your favorite Bollywood and other regional hits all night long!", Name = "BollyWood Fusion Boat Party", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 05, 23, 03, 30, 0) , EndTime = new DateTime(2020, 05, 23, 05, 30, 0), Price = 100M, PictureUrl = "http://baseurltobereplaced/api/pic/10" },
                new EventItem { EventTypeId = 2, Description = "This 45-minute heart-pumping dance workout will keep you burning those calories.", Name = "Virtual Bollywood Cardio", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 13, 10, 30, 0) , EndTime = new DateTime(2020, 04, 13, 11, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/11" },
                new EventItem { EventTypeId = 3, Description = "Let's have family friendly daytime celebration!", Name = "Holi Hai : Color Festival", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/12" },
                new EventItem { EventTypeId = 4, Description = "Come join for some fun with Bhangra dance classes! !", Name = "Learn Bhangra: Bringing BHANGRA to everyone", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 20, 06, 30, 0) , EndTime = new DateTime(2020, 04, 20, 06, 30, 0), Price = 20M, PictureUrl = "http://baseurltobereplaced/api/pic/13" },
                new EventItem { EventTypeId = 4, Description = "Come join us have some fun in Run!", Name = "5K Run", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 05, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/14" },
                new EventItem { EventTypeId = 4, Description = "Come join us !", Name = "Senior Get Together", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 5M, PictureUrl = "http://baseurltobereplaced/api/pic/15" },
            };
        }

        private static IEnumerable<EventType> GetPreConfiguredEventTypes()
        {
            return new List<EventType>
            {
                new EventType{Type = "Music"},
                new EventType{Type = "Educational"},
                new EventType{Type = "Dance"},
                new EventType{Type = "KidsActivities"},
                new EventType{Type = "Fitness"},
                new EventType{Type = "Cooking"}
            };
        }
    }
}
