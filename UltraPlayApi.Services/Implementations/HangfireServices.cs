using Hangfire;
using Hangfire.Storage;

using System.Net.Http;

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

        public void RemoveAllRecurringJobs()
        {
            using (var connection = JobStorage.Current.GetConnection())
            {
                foreach (var recurringJob in StorageConnectionExtensions.GetRecurringJobs(connection))
                {
                    RecurringJob.RemoveIfExists(recurringJob.Id);
                }
            }
        }
    }
}
