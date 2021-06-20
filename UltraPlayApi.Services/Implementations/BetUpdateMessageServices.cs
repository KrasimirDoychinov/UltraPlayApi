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
    public class BetUpdateMessageServices : IUpdateMessageServices
    {
        private readonly ApplicationDbContext context;

        public BetUpdateMessageServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Create(int uniqueId, string description, int id, string oldValue, string newValue)
        {
            var msg = new BetUpdateMessage
            {
                UniqueId = uniqueId,
                Description = description,
                BetId = id,
                OldValue = oldValue,
                NewValue = newValue
            };

            await this.context.BetUpdateMessages.AddAsync(msg);
        }

        public IEnumerable<T> GetAll<T>(IMapper mapper = null)
            => this.context.BetUpdateMessages
            .To<T>(mapper)
            .ToList();
    }
}
