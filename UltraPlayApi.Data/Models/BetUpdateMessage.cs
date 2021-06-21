namespace UltraPlayApi.Data.Models
{
    public class BetUpdateMessage : BaseUpdateMessage
    {
        public int BetId { get; set; }

        public virtual Bet Bet { get; set; }
    }
}
