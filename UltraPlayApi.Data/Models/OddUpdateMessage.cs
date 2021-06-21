namespace UltraPlayApi.Data.Models
{
    public class OddUpdateMessage : BaseUpdateMessage
    {
        public int OddId { get; set; }

        public virtual Odd Odd { get; set; }
    }
}
