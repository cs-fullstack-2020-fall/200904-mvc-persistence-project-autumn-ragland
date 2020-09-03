using Microsoft.EntityFrameworkCore;
using ArtistsInResidency.Models;
namespace ArtistsInResidency.DAO
{
    // database context extending base class
    public class ArtistDbContext : DbContext
    {
        // extend base class constructor, passing in options
        public ArtistDbContext(DbContextOptions<ArtistDbContext> options) : base(options)
        {
        }
        // db set for required models
        public DbSet<ArtistModel> artists{get;set;}
        public DbSet<ArtModel> worksOfArt{get;set;}

    }
}