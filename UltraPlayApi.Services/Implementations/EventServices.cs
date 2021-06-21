using System;
using System.Linq;
using System.Collections.Generic;

using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class EventServices : IEventServices
    {
        private readonly ApplicationDbContext context;
        private readonly ISportServices sportServices;

        public EventServices(ApplicationDbContext context,
            ISportServices sportServices)
        {
            this.context = context;
            this.sportServices = sportServices;
        }

        public IEnumerable<Event> GetAllEvents() =>
            this.context.Events;

        public IEnumerable<Event> FilterEventsByDate(IEnumerable<Event> events)
        {
            var dateNow = DateTime.Now;
            events.AsParallel()
                .ForAll(x => x.Matches = x.Matches.Where(y => (dateNow - y.StartDate).Days == 0)
                .ToList());
            return events.Where(x => x.Matches.Count > 0);
        }

        public void FilterEvent(IEnumerable<Event> currEvents, Event newEvent)
        {
            var foundEvent = currEvents.FirstOrDefault(x => x.UniqueId == newEvent.UniqueId);
            if (foundEvent == null)
            {
                newEvent.SportId = this.sportServices.GetSportId();
                this.context.Events.Add(newEvent);
                Console.WriteLine($"New event added with UniqueID - {newEvent.UniqueId}");
            }

            else if (foundEvent != null && foundEvent.IsLive != newEvent.IsLive)
            {
                this.context.Events.Update(foundEvent);
                foundEvent.IsLive = newEvent.IsLive;
                Console.WriteLine($"Event changed at UniqueID - {foundEvent.UniqueId}");
            }
        }
    }
}
