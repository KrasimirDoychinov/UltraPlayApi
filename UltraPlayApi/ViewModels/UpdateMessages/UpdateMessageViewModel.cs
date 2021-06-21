namespace UltraPlayApi.Web.ViewModels.UpdateMessages
{
    public class UpdateMessageViewModel
    {
        public int Id { get; set; }

        public string UniqueId { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public string Description { get; set; }
    }
}
