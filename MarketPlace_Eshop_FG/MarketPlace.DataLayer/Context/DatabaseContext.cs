﻿using System.Linq;
using MarketPlace.DataLayer.Entities.Account;
using MarketPlace.DataLayer.Entities.Contact;
using MarketPlace.DataLayer.Entities.Products;
using MarketPlace.DataLayer.Entities.Site;
using MarketPlace.DataLayer.Entities.Store;
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

        #region Site

        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SiteBanner> SiteBanners { get; set; }

        #endregion

        #region Contact

        
        public DbSet<ContactUs> ContactUs { get; set; }

        //add Ticket
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }

        #endregion

        #region Store

        public DbSet<Seller> Sellers { get; set; }

        #endregion

        #region Products

        public DbSet<ProductSelectedCategory> ProductSelectedCategories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Product> Products { get; set; }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s=>s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


          

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
