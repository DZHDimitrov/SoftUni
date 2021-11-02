using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FootballBookmakeSystem;Trusted_Connection=True;MultipleActiveResultSets=true");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Color>().HasKey(x => x.ColorId);

            modelBuilder.Entity<Town>((e) => 
            {
                e.HasKey(x => x.TownId);
                e.HasOne(x => x.Country).WithMany(x => x.Towns).HasForeignKey(x => x.CountryId);
            });

            modelBuilder.Entity<Game>((e) => 
            {
                e.HasKey(x => x.GameId);
                e.HasOne(x => x.HomeTeam).WithMany(x => x.HomeGames).HasForeignKey(x => x.HomeTeamId).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(x => x.AwayTeam).WithMany(x => x.AwayGames).HasForeignKey(x => x.AwayTeamId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Player>((e) => 
            {
                e.HasKey(x => x.PlayerId);
                e.HasOne(x => x.Team).WithMany(x => x.Players).HasForeignKey(x => x.TeamId);
                e.HasOne(x => x.Position).WithMany(x => x.Players).HasForeignKey(x => x.PositionId);
            });


            modelBuilder.Entity<Team>((e) =>
            {
                e.HasKey(x => x.TeamId);
                e.HasOne(x => x.PrimaryKitColor).WithMany(x => x.PrimaryKitTeams).HasForeignKey(x => x.PrimaryKitColorId).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(x => x.SecondaryKitColor).WithMany(x => x.SecondaryKitTeams).HasForeignKey(x => x.SecondaryKitColorId).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(x => x.Town).WithMany(x => x.Teams).HasForeignKey(x => x.TownId);
            });

            modelBuilder.Entity<PlayerStatistic>((e) =>
            {
                e.HasKey(x => new { x.PlayerId, x.GameId });
                e.HasOne(x => x.Game).WithMany(x => x.PlayerStatistics).HasForeignKey(x => x.GameId);
                e.HasOne(x => x.Player).WithMany(x => x.PlayerStatistics).HasForeignKey(x => x.PlayerId);
            });

            modelBuilder.Entity<Bet>((e) =>
            {
                e.HasKey(x => x.BetId);
                e.HasOne(x => x.Game).WithMany(x => x.Bets).HasForeignKey(x => x.GameId);
                e.HasOne(x => x.User).WithMany(x => x.Bets).HasForeignKey(x => x.UserId);
                e.Property(x => x.Prediction).IsRequired(true);
            });

        }   
    }
}
