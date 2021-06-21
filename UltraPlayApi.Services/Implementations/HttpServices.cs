using System.Net.Http;
using System.Threading.Tasks;

using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class HttpServices : IHttpServices
    {
        private HttpClient client;
        private HttpResponseMessage response;
        private readonly IXmlServices xmlServices;

        public HttpServices(HttpClient client,
            HttpResponseMessage response,
            IXmlServices xmlServices)
        {
            this.client = client;
            this.response = response;
            this.xmlServices = xmlServices;
        }

        public async Task<string> GetHttpContentAsync(string urlPath)
        {
            using (this.client)
            {
                using (this.response = this.client.GetAsync(urlPath).Result)
                {
                    using (var content = response.Content)
                    {
                        return await xmlServices.EditXmlAsync(content);
                    }
                }
            }
        }

    }
}
