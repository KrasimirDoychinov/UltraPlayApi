using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

using UltraPlayApi.Services.Interfaces;
using UltraPlayApi.Web.ViewModels.Match;

namespace UltraPlayApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchServices matchServices;
        private readonly IOddsServices oddsServices;

        public MatchesController(IMatchServices matchServices, IOddsServices oddsServices)
        {
            this.matchServices = matchServices;
            this.oddsServices = oddsServices;
        }

        [HttpGet("{uniqueId:int}", Name = "Get")]
        public IActionResult GetMatchById(int uniqueId)
        {
            var match = this.matchServices.GetMatchById<MatchViewModel>(uniqueId);
            return this.Ok(match);
        }

        [HttpGet("all")]
        public IActionResult GetMatchesIn24Hours()
        {
            var matches = this.matchServices.GetMatchesIn24Hours<MatchViewModel>();
            var filteredMatches = matches.Where(x => (x.StartDate - DateTime.Now).Days == 0).ToList();

            foreach (var match in filteredMatches)
            {
                foreach (var bet in match.Bets)
                {
                    var hasOddsWithSBT = bet.Odds.Any(x => x.SpecialBetValue != null);
                    if (hasOddsWithSBT)
                    {
                        bet.Odds = bet.Odds.Where(x => x.SpecialBetValue != null).Take(2).ToList();
                    }
                }
            }

            return this.Ok(filteredMatches);
        }
    }
}
