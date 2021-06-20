using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltraPlayApi.Data.Enums;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Web.Dtos.Bets;

namespace UltraPlayApi.Web.ViewModels.Match
{
    public class MatchDto : IMapFrom<UltraPlayApi.Data.Models.Match>
    {
        public string Name { get; set; }

        public int UniqueId { get; set; }

        public DateTime StartDate { get; set; }

        public MatchType MatchType { get; set; }

        public IEnumerable<BetDto> Bets { get; set; }
    }
}
