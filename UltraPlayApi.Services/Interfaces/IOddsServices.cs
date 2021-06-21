using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IOddsServices
    {
        public IEnumerable<Odd> GetAllOdds();

        public Odd FindChangedBet(IEnumerable<Odd> currOdds, Odd newOdd);

        public void UpdateOdd(Odd foundOdd, Odd newOdd);
    }
}
