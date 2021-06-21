﻿namespace UltraPlayApi.Data.Models
{
    public class BetUpdateMessage : BaseUpdateMessage
    {
        public int UniqueId { get; set; }

        public int BetId { get; set; }

        public virtual Bet Bet { get; set; }
    }
}
