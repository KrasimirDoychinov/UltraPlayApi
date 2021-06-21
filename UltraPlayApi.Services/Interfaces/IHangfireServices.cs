namespace UltraPlayApi.Services.Interfaces
{
    public interface IHangfireServices
    {
        public void CallApi();

        public void RemoveAllRecurringJobs();
    }
}
