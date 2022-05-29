using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.DataLayer.Migrations
{
    public partial class Edit_Seller_Guideline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuestionTitle",
                table: "SellerGuidelines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerTitle",
                table: "SellerGuidelines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuestionTitle",
                table: "SellerGuidelines",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerTitle",
                table: "SellerGuidelines",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
