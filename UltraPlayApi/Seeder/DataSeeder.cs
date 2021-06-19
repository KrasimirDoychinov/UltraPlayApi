using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.Interfaces;
using static UltraPlayApi.Data.Common.GlobalConstants;

namespace UltraPlayApi.Web.Seeder
{
    public class DataSeeder
    {
        
        public static async Task ConsumeXml(ISportServices sportServices, IHttpServices httpServices, IXmlServices xmlServices,
            IEventServices eventServices, IMatchServices matchServices, IBetServices betServices, IOddsServices oddsServices,
            ApplicationDbContext context)
        {
            var currSport = sportServices.GetFirstSport();

            var result = await httpServices.GetHttpContentAsync(UrlConstants.XmlUrl);
            var newSport = xmlServices.DeserializeXml<Sport>(result);
            newSport.Events = eventServices.FilterEventsByDate(newSport.Events).ToList();

            if (currSport == null)
            {
                await sportServices.AddSportAsync(newSport);
            }
            else
            {
                FilterEntities(newSport.Events, eventServices, matchServices, betServices, oddsServices);
                await context.SaveChangesAsync();
            }
        }

        private static void FilterEntities(IEnumerable<Event> newEvents, IEventServices eventServices, IMatchServices matchServices,
            IBetServices betServices, IOddsServices oddsServices)
        {
            var currEvents = eventServices.GetAllEvents().ToList();
            var currMatches = matchServices.GetAllMatches().ToList();
            var currBets = betServices.GetAllBets().ToList();
            var currOdds = oddsServices.GetAllOdds().ToList();

            Console.WriteLine("Filtering started.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var newEvent in newEvents)
            {
                eventServices.FilterEvent(currEvents, newEvent);

                foreach (var newMatch in newEvent.Matches)
                {
                    matchServices.FilterMatch(currMatches, newMatch);

                    foreach (var newBet in newMatch.Bets)
                    {
                        betServices.FilterBet(currBets, newBet);

                        foreach (var newOdd in newBet.Odds)
                        {
                            oddsServices.FilterOdd(currOdds, newOdd);
                        }
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Filtering completed. Elapsed time - {stopwatch.ElapsedMilliseconds}");
        }
    }
}
