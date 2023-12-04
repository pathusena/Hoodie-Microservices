using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hoodie.Services.ProductAPI.Migrations
{
    public partial class ProductAPITables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "Supreme", "Supreme moves away from eye-catching branding with this dark grey hoodie, instead opting for a small box logo to the front. This allows for a more pared-back look for the off-duty piece.", "https://cdn-images.farfetch-contents.com/17/75/97/72/17759772_37390075_1000.jpg", "Supreme Box Logo Black Hoodie", 431.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "Supreme", "The Supreme Swarovski box logo hoodie, in navy blue, is one of three colours for the special edition hooded sweatshirt featuring the streetwear brand’s iconic logo constructed in shining crystals. Supreme enlisted Swarovski to help them celebrate their 25th anniversary in 2019 with this luxurious take on the box logo. The design features 1,201 Swarovski red and clear crystals that form the logo. The hoodie is crafted with Supreme's high-quality fleece.", "https://cdn-images.farfetch-contents.com/14/16/50/65/14165065_40949812_1000.jpg", "Supreme x Swarovski Box Logo Hoodie", 1790.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "Supreme", "Supreme's signature blend of relaxed silhouettes and bold branding is reflected in the design of this hoodie. Crafted from cotton, it is punctuated with the label's signature Box Logo to the front.", "https://cdn-images.farfetch-contents.com/17/75/78/45/17757845_37966486_1000.jpg", "Supreme Box Logo White Hoodie", 488.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
