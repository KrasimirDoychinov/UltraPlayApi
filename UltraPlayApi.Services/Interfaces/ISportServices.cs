using AutoMapper;

using System.Threading.Tasks;

using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Services.Interfaces
{
    public interface ISportServices
    {
        public Task AddSportAsync(Sport sport);

        public Sport GetFirstSport(IMapper mapper = null);

        public int GetSportId();
    }
}
