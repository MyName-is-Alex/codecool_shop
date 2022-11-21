using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.DAL;

public class CodecoolShopContext : DbContext 
{
    public CodecoolShopContext(DbContextOptions<CodecoolShopContext> options) : base(options) { }

    //Create the DataSet for the Employee         
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<Supplier> Supplier { get; set; }
    public DbSet<AppUser> AppUser { get; set; }
    public DbSet<ItemModel> ItemModel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Supplier amazon = new Supplier { Id = 1, Name = "Amazon", Description = "Digital content and services" };
        Supplier emag = new Supplier { Id = 2, Name = "EMag", Description = "Everything you think of" };
        Supplier lenovo = new Supplier { Id = 3, Name = "Lenovo", Description = "Computers" };

        ProductCategory tablet = new ProductCategory { Id = 1, Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
        ProductCategory phone = new ProductCategory { Id = 2, Name = "Phone", Department = "Hardware", Description = "A phone, commonly shortened to phone, is a thin, flat mobile computer with a touchscreen display." };

        Product amazonFire = new Product { Id = 1, Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategoryId = 1, SupplierId = 1 };
        Product lenovoIdeaPad = new Product { Id = 2, Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategoryId = 1, SupplierId = 3 };
        Product amazonFireHd = new Product { Id = 3, Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategoryId = 1, SupplierId = 1 };

        modelBuilder.Entity<Supplier>().HasData(amazon, emag, lenovo);

        modelBuilder.Entity<ProductCategory>().HasData(tablet, phone);

        modelBuilder.Entity<Product>().HasData(amazonFire, lenovoIdeaPad, amazonFireHd);
    }
}