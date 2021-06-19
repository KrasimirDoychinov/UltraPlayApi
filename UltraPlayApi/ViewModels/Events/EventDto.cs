using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Web.ViewModels.Match;

namespace UltraPlayApi.Web.ViewModels.Events
{
    public class EventDto : IMapFrom<Event>
    {
        public string Name { get; set; }

        public bool IsLive { get; set; }

        //public string IsLiveParsed => this.IsLive == true ? "Live" : "Not live";

        public IEnumerable<MatchDto> Matches { get; set; }

    }
}
