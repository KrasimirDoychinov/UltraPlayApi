using Microsoft.EntityFrameworkCore;

using UltraPlayApi.Data.Models;

namespace UltraPlayApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<MatchUpdateMessage> MatchUpdateMessages { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<BetUpdateMessage> BetUpdateMessages { get; set; }

        public DbSet<Odd> Odds { get; set; }

        public DbSet<OddUpdateMessage> OddUpdateMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=UltraPlayApi;Integrated Security=true;");
            }

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
