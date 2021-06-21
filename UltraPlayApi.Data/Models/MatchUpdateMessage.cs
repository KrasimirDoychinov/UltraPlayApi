namespace UltraPlayApi.Data.Models
{
    public class MatchUpdateMessage : BaseUpdateMessage
    {
        public int MatchId { get; set; }

        public virtual Match Match { get; set; }
    }
}
