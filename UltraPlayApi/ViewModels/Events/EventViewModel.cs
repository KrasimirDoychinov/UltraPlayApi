using System.Collections.Generic;

using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Web.ViewModels.Match;

namespace UltraPlayApi.Web.ViewModels.Events
{
    public class EventViewModel : IMapFrom<Event>
    {
        public string Name { get; set; }

        public bool IsLive { get; set; }

        public int UniqueId { get; set; }

        public IEnumerable<MatchViewModel> Matches { get; set; }

    }
}
