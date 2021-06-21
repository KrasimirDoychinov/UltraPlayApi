using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.Interfaces;

using static UltraPlayApi.Data.Common.GlobalConstants;

namespace UltraPlayApi.Services.Implementations
{
    public class DataServices : IDataServices
    {
        private readonly ISportServices sportServices;
        private readonly IHttpServices httpServices;
        private readonly IXmlServices xmlServices;
        private readonly IEventServices eventServices;
        private readonly IMatchServices matchServices;
        private readonly IBetServices betServices;
        private readonly IOddsServices oddsServices;
        private readonly ApplicationDbContext context;
        private readonly OddUpdateMessageServices oddUpdateMessageServices;
        private readonly BetUpdateMessageServices betUpdateMessageServices;
        private readonly MatchUpdateMessageServices matchUpdateMessageServices;

        public DataServices(ISportServices sportServices, IHttpServices httpServices, IXmlServices xmlServices,
            IEventServices eventServices, IMatchServices matchServices, IBetServices betServices, IOddsServices oddsServices,
            ApplicationDbContext context, OddUpdateMessageServices oddUpdateMessageServices,
            BetUpdateMessageServices betUpdateMessageServices, MatchUpdateMessageServices matchUpdateMessageServices)
        {
            this.sportServices = sportServices;
            this.httpServices = httpServices;
            this.xmlServices = xmlServices;
            this.eventServices = eventServices;
            this.matchServices = matchServices;
            this.betServices = betServices;
            this.oddsServices = oddsServices;
            this.context = context;
            this.oddUpdateMessageServices = oddUpdateMessageServices;
            this.betUpdateMessageServices = betUpdateMessageServices;
            this.matchUpdateMessageServices = matchUpdateMessageServices;
        }

        public async Task ConsumeXml()
        {
            var currSport = this.sportServices.GetFirstSport();

            var result = await this.httpServices.GetHttpContentAsync(UrlConstants.XmlUrl);
            var newSport = this.xmlServices.DeserializeXml<Sport>(result);
            newSport.Events = this.eventServices.FilterEventsByDate(newSport.Events).ToList();

            if (currSport == null)
            {
                await this.sportServices.AddSportAsync(newSport);
            }
            else
            {
                await this.FilterEntities(newSport.Events);
                await this.context.SaveChangesAsync();
            }
        }

        // I use Console.WriteLine here for easier debugging.
        public async Task FilterEntities(IEnumerable<Event> newEvents)
        {
            var currEvents = this.eventServices.GetAllEvents().ToList();
            var currMatches = this.matchServices.GetAllMatches().ToList();
            var currBets = this.betServices.GetAllBets().ToList();
            var currOdds = this.oddsServices.GetAllOdds().ToList();

            Console.WriteLine("Filtering started.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var newEvent in newEvents)
            {
                this.eventServices.FilterEvent(currEvents, newEvent);

                foreach (var newMatch in newEvent.Matches)
                {
                    var foundMatch = this.matchServices.FindChangedMatch(currMatches, newMatch);
                    if (foundMatch != null)
                    {
                        await this.matchUpdateMessageServices.Create(foundMatch.UniqueId,
                                $"MatchType changed from - {foundMatch.MatchType} to {newMatch.MatchType}", foundMatch.Id,
                                foundMatch.MatchType.ToString(), newMatch.MatchType.ToString());
                        Console.WriteLine($"MatchType changed from - {foundMatch.MatchType} to {newMatch.MatchType}");

                        this.matchServices.UpdateMatch(foundMatch, newMatch);
                    }

                    foreach (var newBet in newMatch.Bets)
                    {
                        var foundBet = this.betServices.FindChangedBet(currBets, newBet);
                        if (foundBet != null)
                        {
                            await this.betUpdateMessageServices.Create(foundBet.UniqueId,
                                    $"IsLive changed from - {foundBet.IsLive} to {newBet.IsLive}",
                                    foundBet.Id, foundBet.IsLive.ToString(), newBet.IsLive.ToString());
                            Console.WriteLine($"IsLive changed from - {foundBet.IsLive} to {newBet.IsLive}");

                            this.betServices.UpdateBet(foundBet, newBet);
                        }

                        foreach (var newOdd in newBet.Odds)
                        {
                            var foundOdd = this.oddsServices.FindChangedBet(currOdds, newOdd);
                            if (foundOdd != null)
                            {
                                await this.oddUpdateMessageServices.Create(foundOdd.UniqueId,
                                        $"Value changed from - {foundOdd.Value} to {newOdd.Value}", foundOdd.Id,
                                        foundOdd.Value.ToString(), newOdd.Value.ToString());
                                Console.WriteLine($"Value changed from - {foundOdd.Value} to {newOdd.Value}");

                                this.oddsServices.UpdateOdd(foundOdd, newOdd);
                            }

                        }
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Filtering completed. Elapsed time - {stopwatch.ElapsedMilliseconds}");
        }

        
    }
}
