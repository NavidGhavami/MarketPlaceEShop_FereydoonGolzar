using MarketPlace.DataLayer.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DataLayer.Context
{
    public class DatabaseContext : DbContext
    {
        #region DbSet

        public DbSet<User> Users { get; set; }

        #endregion
    }
}
