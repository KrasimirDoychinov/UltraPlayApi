using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IMatchServices
    {
        public IEnumerable<Match> GetAllMatches();

        public void FilterMatch(IEnumerable<Match> currMatches, Match newMatch);
    }
}
