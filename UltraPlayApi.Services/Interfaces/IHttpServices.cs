using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IHttpServices
    {
        public Task<string> GetHttpContentAsync(string urlPath);
    }
}
