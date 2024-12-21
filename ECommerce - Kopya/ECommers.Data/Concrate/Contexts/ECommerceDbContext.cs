using ECommers.Entity.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Data.Concrate.Contexts
{
    public class ECommerceDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });
            base.OnModelCreating(builder);

        }
    }

}
