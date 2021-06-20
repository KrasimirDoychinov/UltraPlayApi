using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltraPlayApi.Web.Dtos.UpdateMessages
{
    public class UpdateMessageDto
    {
        public int Id { get; set; }

        public string UniqueId { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public string Description { get; set; }
    }
}
