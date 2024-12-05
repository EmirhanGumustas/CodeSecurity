using Microsoft.EntityFrameworkCore;
using Proje0001.Entities;

namespace Proje0001.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<UserIp> UserIps { get; set; }
        public DbSet<UserAbout> UserAbout { get; set; }
        public DbSet<UserBadWord> UserBadWords { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // database ile ilgili
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9EI32UN\\SQLEXPRESS;Database=ExampleDatabase;User=sa;Password=1234;TrustServerCertificate=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasMany(x => x.Users).WithOne(x => x.Language).HasForeignKey(x => x.LanguageId);
            //bir dilin birden fazla kullanıcı olabilir.bir kullanıcı bir dil kullanabilir.
            modelBuilder.Entity<User>().HasMany(x => x.UserIps).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<User>().HasOne(x => x.UserAbout).WithOne(x => x.User);
            modelBuilder.Entity<User>().HasMany(x => x.UserBadWords).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
