using System;
using System.Collections.Generic;

using UltraPlayApi.Data.Enums;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Web.Dtos.Bets;

namespace UltraPlayApi.Web.ViewModels.Match
{
    public class MatchViewModel : IMapFrom<UltraPlayApi.Data.Models.Match>
    {
        public string Name { get; set; }

        public int UniqueId { get; set; }

        public DateTime StartDate { get; set; }

        public MatchType MatchType { get; set; }

        public IEnumerable<BetViewModel> Bets { get; set; }
    }
}
