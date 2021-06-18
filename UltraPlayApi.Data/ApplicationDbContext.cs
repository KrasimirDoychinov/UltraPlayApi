using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Odd> Odds { get; set; }

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

            builder.Entity<Sport>()
                .HasMany(x => x.Events)
                .WithOne(y => y.Sport)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Event>()
                .HasMany(x => x.Matches)
                .WithOne(y => y.Event)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Match>()
                .HasMany(x => x.Bets)
                .WithOne(y => y.Match)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Bet>()
                .HasMany(x => x.Odds)
                .WithOne(y => y.Bet)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
