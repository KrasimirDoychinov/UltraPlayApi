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

        public async Task FilterMatch(IEnumerable<Match> currMatches, Match newMatch)
        {
            var foundMatch = currMatches
                        .FirstOrDefault(x => x.UniqueId == newMatch.UniqueId && x.MatchType != newMatch.MatchType);
            if (foundMatch != null)
            {
                this.context.Matches.Update(foundMatch);
                await this.matchUpdateMessageServices.Create(foundMatch.UniqueId, 
                    $"MatchType changed from - {foundMatch.MatchType} to {newMatch.MatchType}", foundMatch.Id,
                    foundMatch.MatchType.ToString(), newMatch.MatchType.ToString());

                Console.WriteLine($"MatchType changed from - {foundMatch.MatchType} to {newMatch.MatchType}");

                foundMatch.MatchType = newMatch.MatchType;
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
