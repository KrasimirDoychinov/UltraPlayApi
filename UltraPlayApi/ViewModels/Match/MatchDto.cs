using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltraPlayApi.Data.Enums;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Web.ViewModels.Bets;

namespace UltraPlayApi.Web.ViewModels.Match
{
    public class MatchDto : IMapFrom<UltraPlayApi.Data.Models.Match>
    {
        public string Name { get; set; }

        //public string TeamA => this.Name.Split(" - ")[0];

        //public string TeamB => this.Name.Split(" - ")[1];

        public MatchType MatchType { get; set; }

        //public string MatchTypeParsed => this.MatchType.ToString();

        public IEnumerable<BetDto> Bets { get; set; }

    //    public BetDto MatchWinnerBet => this.Bets.FirstOrDefault(x => x.Name == "Match Winner");

    //    public string TeamAOdds => this.MatchWinnerBet == null ? null : this.MatchWinnerBet.Odds.ToList()[0].Value;

    //    public string TeamBOdds => this.MatchWinnerBet == null ? null : this.MatchWinnerBet.Odds.ToList()[1].Value;
    }
}
