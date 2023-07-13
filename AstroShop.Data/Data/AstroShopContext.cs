using AstroShop.Data.Data.CMS;
using AstroShop.Data.Data.Shop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShop.Data.Data
{
    public class AstroShopContext : DbContext
    {
        //context file represents whole database
        public AstroShopContext(DbContextOptions<AstroShopContext> options)
            : base(options)
        {
        }

        public DbSet<Page> Page { get; set; }
        public DbSet<Shop.Type> Type { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ProductsLinks> ProductsLinks { get; set; }
        public DbSet<FooterLinks> FooterLinks { get; set; }
        public DbSet<SocialLinks> SocialLinks { get; set; }
        public DbSet<ContactLinks> ContactLinks { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogType> BlogType { get; set; }
        public DbSet<CartElement> CartElement { get; set; }
        public DbSet<WishlistElement> WishlistElement { get; set; }
    }
}
