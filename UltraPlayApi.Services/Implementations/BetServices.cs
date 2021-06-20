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
    public class BetServices : IBetServices
    {
        private readonly BetUpdateMessageServices betUpdateMessageServices;
        private readonly ApplicationDbContext context;

        public BetServices(BetUpdateMessageServices betUpdateMessageServices, ApplicationDbContext context)
        {
            this.betUpdateMessageServices = betUpdateMessageServices;
            this.context = context;
        }

        public IEnumerable<Bet> GetAllBets()
            => this.context.Bets;

        public async Task FilterBet(IEnumerable<Bet> currBets, Bet newBet)
        {
            var foundBet = currBets
                                  .FirstOrDefault(x => x.UniqueId == newBet.UniqueId && x.IsLive != newBet.IsLive);
            if (foundBet != null)
            {
                this.context.Bets.Update(foundBet);
                await this.betUpdateMessageServices.Create(foundBet.UniqueId, 
                    $"IsLive changed from - {foundBet.IsLive} to {newBet.IsLive}",
                    foundBet.Id, foundBet.IsLive.ToString(), newBet.IsLive.ToString());

                Console.WriteLine($"IsLive changed from - {foundBet.IsLive} to {newBet.IsLive}");

                foundBet.IsLive = newBet.IsLive;
            }
        }

        
    }
}
