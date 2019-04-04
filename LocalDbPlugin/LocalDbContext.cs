using System.Configuration;
using System.Data.Entity;
using Common.Models;

namespace Data
{
    public class LocalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public LocalDbContext() : base("xyzxyzxyzxyzxyzxyzxyzxyz")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Create PK
            modelBuilder.Entity<User>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Actor>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Director>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Movie>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Rating>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Country>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Genre>()
                .HasKey(t => t.Id);

            //Create FK
            modelBuilder.Entity<Movie>()
                .HasMany<Actor>(t => t.Actors)
                .WithMany(t => t.Movies)
                .Map(t =>
                {
                    t.MapLeftKey("MovieRefId");
                    t.MapRightKey("ActorRefId");
                    t.ToTable("MovieActor");
                });
            modelBuilder.Entity<Movie>()
                .HasMany<Director>(t => t.Directors)
                .WithMany(t => t.Movies)
                .Map(t =>
                {
                    t.MapLeftKey("MovieRefId");
                    t.MapRightKey("ActorRefId");
                    t.ToTable("MovieDirector");
                });
            modelBuilder.Entity<Movie>()
                .HasMany<Country>(t => t.Countries)
                .WithMany(t => t.Movies)
                .Map(t =>
                {
                    t.MapLeftKey("MovieRefId");
                    t.MapRightKey("CountryRefId");
                    t.ToTable("MovieCountry");
                });
            modelBuilder.Entity<Movie>()
                .HasMany<Genre>(t => t.Genres)
                .WithMany(t => t.Movies)
                .Map(t =>
                {
                    t.MapLeftKey("MovieRefId");
                    t.MapRightKey("GenreRefId");
                    t.ToTable("MovieGenre");
                });
            modelBuilder.Entity<Rating>()
                .HasRequired<User>(t => t.User)
                .WithMany(t => t.RatingMovies);
            modelBuilder.Entity<Rating>()
                .HasRequired<Movie>(t => t.Movie)
                .WithMany(t => t.Ratings);

            base.OnModelCreating(modelBuilder);
        }
    }
}
