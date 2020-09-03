using Microsoft.EntityFrameworkCore;
using ArtistsInResidency.Models;
namespace ArtistsInResidency.DAO
{
    public class ArtistDbContext : DbContext
    {
        public ArtistDbContext(DbContextOptions<ArtistDbContext> options) : base(options)
        {
        }
        public DbSet<ArtistModel> artists{get;set;}
        public DbSet<ArtModel> worksOfArt{get;set;}

    }
}