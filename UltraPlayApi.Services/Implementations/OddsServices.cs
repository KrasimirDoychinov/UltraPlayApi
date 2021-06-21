using System.Linq;
using System.Collections.Generic;

using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class OddsServices : IOddsServices
    {
        private readonly OddUpdateMessageServices oddUpdateMessageServices;
        private readonly ApplicationDbContext context;

        public OddsServices(OddUpdateMessageServices oddUpdateMessageServices,ApplicationDbContext context)
        {
            this.oddUpdateMessageServices = oddUpdateMessageServices;
            this.context = context;
        }

        public IEnumerable<Odd> GetAllOdds()
            => this.context.Odds;

        public Odd FindChangedBet(IEnumerable<Odd> currOdds, Odd newOdd)
            => currOdds.FirstOrDefault(x => x.UniqueId == newOdd.UniqueId && x.Value != newOdd.Value);

        public void UpdateOdd(Odd foundOdd, Odd newOdd)
        {
            this.context.Odds.Update(foundOdd);
            foundOdd.Value = newOdd.Value;
        }
    }
}
