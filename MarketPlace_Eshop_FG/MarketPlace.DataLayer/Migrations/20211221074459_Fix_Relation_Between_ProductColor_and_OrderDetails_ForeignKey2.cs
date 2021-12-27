using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.DataLayer.Migrations
{
    public partial class Fix_Relation_Between_ProductColor_and_OrderDetails_ForeignKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "OrderDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "OrderDetails",
                type: "bigint",
                nullable: true);
        }
    }
}
