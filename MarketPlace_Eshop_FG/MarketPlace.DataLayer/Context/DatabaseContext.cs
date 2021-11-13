using System.Linq;
using MarketPlace.DataLayer.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DataLayer.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }

        #region Account

        public DbSet<User> Users { get; set; }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s=>s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
