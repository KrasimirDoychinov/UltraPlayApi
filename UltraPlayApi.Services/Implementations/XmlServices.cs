using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UltraPlayApi.Data;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.Interfaces;
using System.IO;

namespace UltraPlayApi.Services.Implementations
{
    public class XmlServices : IXmlServices
    {
        private HttpClient client;
        private HttpResponseMessage response;

        public XmlServices(HttpClient client, 
            HttpResponseMessage response)
        {
            this.client = client;
			this.response = response;
        }

        public async Task<string> EditXmlAsync(HttpContent content)
        {
            var asyncResult = await content.ReadAsStringAsync();
            var result = asyncResult;
            result = result.Replace("utf-16", "utf-8");

            var doc = new XmlDocument();
            doc.LoadXml(result);

            return doc.DocumentElement.InnerXml;
        }

        public T DeserializeXml<T>(string xmlString)
        {
            using (TextReader reader = new StringReader(xmlString))
            {
                var serializer = new XmlSerializer(typeof(T));
                var result = (T)serializer.Deserialize(reader);
                return result;
            }
        }

    }
}
