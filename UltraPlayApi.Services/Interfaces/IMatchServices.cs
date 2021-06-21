using AutoMapper;

using System.Collections.Generic;

using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IMatchServices
    {
        public IEnumerable<Match> GetAllMatches();

        public T GetMatchById<T>(int uniqueId, IMapper mapper = null);

        public IEnumerable<T> GetMatchesIn24Hours<T>(IMapper mapper = null);

        public Match FindChangedMatch(IEnumerable<Match> currMatches, Match newMatch);

        public void UpdateMatch(Match foundMatch, Match newMatch);
    }
}
