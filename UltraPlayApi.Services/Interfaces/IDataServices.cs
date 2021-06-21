using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.Implementations;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IDataServices
    {
        public Task ConsumeXml();

        public Task FilterEntities(IEnumerable<Event> newEvents);
    }
}
