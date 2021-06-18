using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IEventServices
    {
        void FilterEvent(IEnumerable<Event> currEvents, Event newEvent);

        public IEnumerable<Event> GetAllEvents();

        public IEnumerable<Event> FilterEventsByDate(IEnumerable<Event> events);

    }
}
