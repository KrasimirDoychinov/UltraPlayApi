using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IOddsServices
    {
        public IEnumerable<Odd> GetAllOdds();

        public void FilterOdd(IEnumerable<Odd> currOdds, Odd newOdd);
    }
}
