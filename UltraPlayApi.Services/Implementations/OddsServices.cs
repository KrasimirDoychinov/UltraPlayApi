using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class OddsServices : IOddsServices
    {
        private readonly ApplicationDbContext context;

        public OddsServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Odd> GetAllOdds()
            => this.context.Odds;

        public void FilterOdd(IEnumerable<Odd> currOdds, Odd newOdd)
        {
            var foundOdd = currOdds
                                .FirstOrDefault(x => x.UniqueId == newOdd.UniqueId && x.Value != newOdd.Value);
            if (foundOdd != null)
            {
                this.context.Odds.Update(foundOdd);
                foundOdd.Value = newOdd.Value;
                Console.WriteLine($"Odd changed at UniqueId - {foundOdd.UniqueId}");
            }
        }

    }
}
