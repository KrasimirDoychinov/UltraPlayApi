using AutoMapper;
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

        public T GetMatchById<T>(int uniqueId, IMapper mapper = null);

        public IEnumerable<T> GetMatchesIn24Hours<T>(IMapper mapper = null);

        public Task FilterMatch(IEnumerable<Match> currMatches, Match newMatch);
    }
}
