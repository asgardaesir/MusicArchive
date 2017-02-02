using System.Data.Entity;
using MusicArchive.Models;

namespace MusicArchive
{
    public class MusicArchiveContext : DbContext
    {
        public DbSet<Artist> Arists { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Label> Labels { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public MusicArchiveContext() : base("MusicArchiveDatabase")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MusicArchiveContext>());
        }
    }
}