using System.Linq;
using MarketPlace.DataLayer.Entities.Account;
using MarketPlace.DataLayer.Entities.Blog;
using MarketPlace.DataLayer.Entities.ChatRoom;
using MarketPlace.DataLayer.Entities.Contact;
using MarketPlace.DataLayer.Entities.ProductComment;
using MarketPlace.DataLayer.Entities.ProductDiscount;
using MarketPlace.DataLayer.Entities.ProductOrder;
using MarketPlace.DataLayer.Entities.Products;
using MarketPlace.DataLayer.Entities.Shipping;
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
        public DbSet<Role> Roles { get; set; }

        #endregion

        #region Site

        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SiteBanner> SiteBanners { get; set; }
        public DbSet<FrequentlyQuestion> FrequentlyQuestions { get; set; }
        public DbSet<SellerGuideline> SellerGuidelines { get; set; }
        public DbSet<SiteGuideline> SiteGuidelines { get; set; }

        #endregion

        #region Chat Room

        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        #endregion

        #region Contact


        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }

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
        public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Product> Products { get; set; }

        #endregion

        #region Product Discount

        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductDiscountUse> ProductDiscountUses { get; set; }

        #endregion

        #region Product Comment

        public DbSet<ProductComment> ProductComments { get; set; }

        #endregion

        #region Product Shipping

        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShippingTrackingCode> ShippingTrackingCodes { get; set; }

        #endregion

        #region Blog

        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        #endregion

        #region Order

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        

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
