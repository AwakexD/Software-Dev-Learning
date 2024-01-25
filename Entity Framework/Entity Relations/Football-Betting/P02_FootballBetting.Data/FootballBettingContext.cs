using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
            
        }

        public FootballBettingContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TownId);

                entity.Property(n => n.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(100);

                entity.Property(x => x.Initials)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(3);


                // Relations

                entity
                    .HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.Town)
                    .WithMany(town => town.Teams)
                    .HasForeignKey(t => t.TownId);

            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);
                    
                entity
                    .HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity
                    .HasMany(c => c.Towns)
                    .WithOne(t => t.Country)
                    .HasForeignKey(c => c.TownId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.PlayerId);

                entity.Property(p => p.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(30);

                entity
                    .HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId);

                entity
                    .HasOne(p => p.Position)
                    .WithMany(pos => pos.Players)
                    .HasForeignKey(p => p.PositionId);

                entity
                    .HasOne(p => p.Town)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TownId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new
                {
                    ps.PlayerId,
                    ps.GameId,
                });

                entity
                    .HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId);

                entity
                    .HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistic)
                    .HasForeignKey(ps => ps.GameId);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity
                    .HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(g => g.BetId);

                entity
                    .HasOne(b => b.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId);
            });
        }
    }
}
