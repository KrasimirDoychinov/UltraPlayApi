using System.Threading.Tasks;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IHttpServices
    {
        public Task<string> GetHttpContentAsync(string urlPath);
    }
}
