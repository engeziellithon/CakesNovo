using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cakes.Data.Migrations
{
    public partial class ProductCategoryImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "public",
                table: "ProductCategory",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "public",
                table: "ProductCategory");
        }
    }
}
