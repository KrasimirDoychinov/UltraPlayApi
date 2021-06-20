using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IBetServices
    {
        public IEnumerable<Bet> GetAllBets();

        public Task FilterBet(IEnumerable<Bet> currBets, Bet newBet);
    }
}
