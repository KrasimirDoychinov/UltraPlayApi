﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayApi.Data.Models
{
    public class MatchUpdateMessage : BaseUpdateMessage
    {
        public int UniqueId { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }
    }
}