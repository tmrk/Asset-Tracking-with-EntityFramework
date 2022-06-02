using Microsoft.EntityFrameworkCore;

namespace AssetTrackingEntityFramework
{
    public class MyDbContext : DbContext
    {
        public DbSet<Asset>? Assets { get; set; }

        string ConnectionString = @"Data Source = S4D01; Initial Catalog = Assets; Integrated Security = True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

    }
}
