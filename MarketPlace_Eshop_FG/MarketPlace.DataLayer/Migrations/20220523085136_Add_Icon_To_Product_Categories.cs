using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.DataLayer.Migrations
{
    public partial class Add_Icon_To_Product_Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "ProductCategories",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "ProductCategories");
        }
    }
}
