using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task FilterOdd(IEnumerable<Odd> currOdds, Odd newOdd)
        {
            var foundOdd = currOdds.FirstOrDefault(x => x.UniqueId == newOdd.UniqueId && x.Value != newOdd.Value);
            if (foundOdd != null)
            {
                this.context.Odds.Update(foundOdd);
                await this.oddUpdateMessageServices.Create(foundOdd.UniqueId,
                    $"Value changed from - {foundOdd.Value} to {newOdd.Value}", foundOdd.Id,
                    foundOdd.Value.ToString(), newOdd.Value.ToString());

                Console.WriteLine($"Value changed from - {foundOdd.Value} to {newOdd.Value}");

                foundOdd.Value = newOdd.Value;
            }
        }
    }
}
