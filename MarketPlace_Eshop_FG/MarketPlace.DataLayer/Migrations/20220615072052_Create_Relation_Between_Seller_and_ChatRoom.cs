using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.DataLayer.Migrations
{
    public partial class Create_Relation_Between_Seller_and_ChatRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SellerId",
                table: "ChatRooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_SellerId",
                table: "ChatRooms",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_Sellers_SellerId",
                table: "ChatRooms",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_Sellers_SellerId",
                table: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_SellerId",
                table: "ChatRooms");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "ChatRooms");
        }
    }
}
