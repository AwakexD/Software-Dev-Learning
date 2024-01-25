using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub.Data
{
    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
            
        }

        public MusicHubDbContext(DbContextOptions options) 
            : base(options)
        {
           
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }

        public DbSet<Performer> Performsers { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<SongPerformer> SongPerformers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.SongId,
                    x.PerformerId
                });

                entity.HasOne(sp => sp.Song)
                    .WithMany(s => s.SongPerformers)
                    .HasForeignKey(sp => sp.SongId);

                entity.HasOne(sp => sp.Performer)
                    .WithMany(p => p.PerformerSongs)
                    .HasForeignKey(sp => sp.PerformerId);
            });
        }
    }
}
