using System.Net.Http;
using System.Threading.Tasks;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IXmlServices
    {

        public Task<string> EditXmlAsync(HttpContent content);

        public T DeserializeXml<T>(string fileName);

    }
}
