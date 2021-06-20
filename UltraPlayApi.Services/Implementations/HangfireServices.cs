using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UltraPlayApi.Services.Interfaces;

namespace UltraPlayApi.Services.Implementations
{
    public class HangfireServices : IHangfireServices
    {
        // This method is not async, because it is called by Hangfire. Hangfire doesn't allow awaiting async methods.
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
