using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IBetServices
    {
        public IEnumerable<Bet> GetAllBets();

        public void FilterBet(IEnumerable<Bet> currBets, Bet newBet);
    }
}
