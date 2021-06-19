using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;

namespace UltraPlayApi.Web.ViewModels.Odds
{
    public class OddDto : IMapFrom<Odd>
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string SpecialBetValue { get; set; }

        public int UniqueId { get; set; }

    }
}
