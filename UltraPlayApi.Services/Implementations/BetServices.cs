using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class BetServices : IBetServices
    {
        private readonly ApplicationDbContext context;

        public BetServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Bet> GetAllBets()
            => this.context.Bets;

        public void FilterBet(IEnumerable<Bet> currBets, Bet newBet)
        {
            var foundBet = currBets
                                  .FirstOrDefault(x => x.UniqueId == newBet.UniqueId && x.IsLive != newBet.IsLive);
            if (foundBet != null)
            {
                this.context.Bets.Update(foundBet);
                foundBet.IsLive = newBet.IsLive;
                Console.WriteLine($"Bet changed at UniqueID - {foundBet.UniqueId}");
            }
        }

        
    }
}
