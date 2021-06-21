using System.Collections.Generic;

using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Web.ViewModels.Odds;

namespace UltraPlayApi.Web.Dtos.Bets
{
    public class BetViewModel : IMapFrom<Bet>
    {
		public string Name { get; set; }

		public bool IsLive { get; set; }

		public int UniqueId { get; set; }

		public IEnumerable<OddViewModel> Odds { get; set; }
	}
}
