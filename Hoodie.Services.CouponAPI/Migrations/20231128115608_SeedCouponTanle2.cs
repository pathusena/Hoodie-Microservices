using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hoodie.Services.CouponAPI.Migrations
{
    public partial class SeedCouponTanle2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponCode", "DiscountAmount", "MiniAmount" },
                values: new object[] { 3, "30OFF", 30.0, 70 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 3);
        }
    }
}
