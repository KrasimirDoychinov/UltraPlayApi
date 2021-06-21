using System;

namespace UltraPlayApi.Data.Models
{
    public class BaseUpdateMessage
    {
        public int Id { get; set; }

        public int UniqueId { get; set; }

        public string Description { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime CreatedOn => DateTime.UtcNow;
    }
}
