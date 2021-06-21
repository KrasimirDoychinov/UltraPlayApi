using AutoMapper;

using System;
using System.Linq;
using System.Collections.Generic;

using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class MatchServices : IMatchServices
    {
        private readonly MatchUpdateMessageServices matchUpdateMessageServices;
        private readonly ApplicationDbContext context;
        private DateTime dateNow = DateTime.Now;
        public MatchServices(MatchUpdateMessageServices matchUpdateMessageServices,ApplicationDbContext context)
        {
            this.matchUpdateMessageServices = matchUpdateMessageServices;
            this.context = context;
        }

        public IEnumerable<Match> GetAllMatches() =>
            this.context.Matches;

        public Match FindChangedMatch(IEnumerable<Match> currMatches, Match newMatch)
            => currMatches
            .FirstOrDefault(x => x.UniqueId == newMatch.UniqueId && x.MatchType != newMatch.MatchType);
        
        public T GetMatchById<T>(int uniqueId, IMapper mapper = null)
             => this.context.Matches
            .Where(x => x.UniqueId == uniqueId)
            .To<T>(mapper)
            .FirstOrDefault();

        public IEnumerable<T> GetMatchesIn24Hours<T>(IMapper mapper = null)
            => this.context.Matches
            .To<T>(mapper)
            .ToList();

        public void UpdateMatch(Match foundMatch, Match newMatch)
        {
            this.context.Matches.Update(foundMatch);
            foundMatch.MatchType = newMatch.MatchType;
        }

    }
}
