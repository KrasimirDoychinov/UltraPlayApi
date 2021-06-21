using System.Threading.Tasks;
using System.Collections.Generic;

using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IDataServices
    {
        public Task ConsumeXml();

        public Task FilterEntities(IEnumerable<Event> newEvents);
    }
}
