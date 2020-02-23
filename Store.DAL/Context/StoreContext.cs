using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryID);
            modelBuilder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(x => x.CategoryID);
            modelBuilder.Entity<Category>()
                .HasData(
               new Category[]
               {
                   new Category { CategoryID = 1, CategoryName = "laptop"},
                   new Category { CategoryID = 2, CategoryName = "phone"}
               });

        }

    }
}
