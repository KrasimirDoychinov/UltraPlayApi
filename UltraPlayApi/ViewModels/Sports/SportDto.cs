using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Web.ViewModels.Events;

namespace UltraPlayApi.Web.ViewModels.Sports
{
    public class SportDto : IMapFrom<Sport>
    {
        public string Name { get; set; }

        public int UniqueId { get; set; }

        public IEnumerable<EventDto> Events { get; set; }
    }
}
