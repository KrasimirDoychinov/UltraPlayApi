using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Web.ViewModels.Odds;

namespace UltraPlayApi.Web.Dtos.Bets
{
    public class BetDto : IMapFrom<Bet>
    {
		public string Name { get; set; }

		public bool IsLive { get; set; }

		public int UniqueId { get; set; }

		public IEnumerable<OddDto> Odds { get; set; }
	}
}
