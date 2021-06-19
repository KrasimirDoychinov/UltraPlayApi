using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class HangfireServices : IHangfireServices
    {

        public void CallApi()
        {
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync("https://localhost:5001/api/hangfire").Result)
                {
                }
            }
        }
    }
}
