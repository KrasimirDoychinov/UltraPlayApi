using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IXmlServices
    {

        public Task<string> EditXmlAsync(HttpContent content);

        public T DeserializeXml<T>(string fileName);

    }
}
