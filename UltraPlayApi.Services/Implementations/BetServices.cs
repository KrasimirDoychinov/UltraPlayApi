using System.Collections.Generic;
using System.Linq;

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
            => this.context.Bets
            .ToList();

        public Bet FindChangedBet(IEnumerable<Bet> currBets, Bet newBet)
            => currBets.FirstOrDefault(x => x.UniqueId == newBet.UniqueId && x.IsLive != newBet.IsLive);

        public void UpdateBet(Bet foundBet, Bet newBet)
        {
            this.context.Bets.Update(foundBet);
            foundBet.IsLive = newBet.IsLive;
        }

    }
}
