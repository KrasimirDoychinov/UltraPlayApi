using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class MatchServices : IMatchServices
    {
        private readonly ApplicationDbContext context;
        private DateTime dateNow = DateTime.Now;
        public MatchServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Match> GetAllMatches() =>
            this.context.Matches;

        public void FilterMatch(IEnumerable<Match> currMatches, Match newMatch)
        {
            var foundMatch = currMatches
                        .FirstOrDefault(x => x.UniqueId == newMatch.UniqueId && x.MatchType != newMatch.MatchType);
            if (foundMatch != null)
            {
                this.context.Matches.Update(foundMatch);
                foundMatch.MatchType = newMatch.MatchType;
                Console.WriteLine($"Match changed at UniqueID - {foundMatch.UniqueId}");
            }
        }

        public T GetMatchById<T>(int uniqueId, IMapper mapper = null)
             => this.context.Matches
            .Where(x => x.UniqueId == uniqueId)
            .To<T>(mapper)
            .FirstOrDefault();

        public IEnumerable<T> GetMatchesIn24Hours<T>(IMapper mapper = null)
            => this.context.Matches
            .To<T>(mapper)
            .ToList();
    }
}
