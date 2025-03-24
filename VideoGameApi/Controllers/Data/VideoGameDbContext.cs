using Microsoft.EntityFrameworkCore;
using VideoGameApi.Model;

namespace VideoGameApi.Controllers.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<VideoGameDetails> VideoGameDetails => Set<VideoGameDetails>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                    new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch" },
                    new VideoGame { Id = 2, Title = "Super Mario Odyssey", Platform = "Nintendo Switch" },
                    new VideoGame { Id = 3, Title = "The Witcher 3: Wild Hunt", Platform = "PlayStation 4" },
                    new VideoGame { Id = 4, Title = "Red Dead Redemption 2", Platform = "PlayStation 4" },
                    new VideoGame { Id = 5, Title = "The Last of Us Part II", Platform = "PlayStation 4" }
            );
        }
    }
}
