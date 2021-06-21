using AutoMapper;

using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;
using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class MatchUpdateMessageServices : IUpdateMessageServices
    {
        private readonly ApplicationDbContext context;

        public MatchUpdateMessageServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Create(int uniqueId, string description, int id, string oldValue, string newValue)
        {
            var msg = new MatchUpdateMessage
            {
                UniqueId = uniqueId,
                Description = description,
                MatchId = id,
                OldValue = oldValue,
                NewValue = newValue
            };

            await this.context.MatchUpdateMessages.AddAsync(msg);
        }

        public IEnumerable<T> GetAll<T>(IMapper mapper = null)
            => this.context.MatchUpdateMessages
                .To<T>(mapper)
                .ToList();
    }
}
