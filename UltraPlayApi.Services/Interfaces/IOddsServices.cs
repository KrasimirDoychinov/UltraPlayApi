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

        public Task FilterOdd(IEnumerable<Odd> currOdds, Odd newOdd);
    }
}
