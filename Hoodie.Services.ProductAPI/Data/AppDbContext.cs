using Hoodie.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Hoodie.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product { 
                ProductId = 1,
                Name = "Supreme Box Logo Black Hoodie",
                Price = 431,
                Description = "Supreme moves away from eye-catching branding with this dark grey hoodie, instead opting for a small box logo to the front. This allows for a more pared-back look for the off-duty piece.",
                ImageUrl = "https://cdn-images.farfetch-contents.com/17/75/97/72/17759772_37390075_1000.jpg",
                CategoryName = "Supreme"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Supreme x Swarovski Box Logo Hoodie",
                Price = 1790,
                Description = "The Supreme Swarovski box logo hoodie, in navy blue, is one of three colours for the special edition hooded sweatshirt featuring the streetwear brand’s iconic logo constructed in shining crystals. Supreme enlisted Swarovski to help them celebrate their 25th anniversary in 2019 with this luxurious take on the box logo. The design features 1,201 Swarovski red and clear crystals that form the logo. The hoodie is crafted with Supreme's high-quality fleece.",
                ImageUrl = "https://cdn-images.farfetch-contents.com/14/16/50/65/14165065_40949812_1000.jpg",
                CategoryName = "Supreme"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Supreme Box Logo White Hoodie",
                Price = 488,
                Description = "Supreme's signature blend of relaxed silhouettes and bold branding is reflected in the design of this hoodie. Crafted from cotton, it is punctuated with the label's signature Box Logo to the front.",
                ImageUrl = "https://cdn-images.farfetch-contents.com/17/75/78/45/17757845_37966486_1000.jpg",
                CategoryName = "Supreme"
            });
        }
    }
}
