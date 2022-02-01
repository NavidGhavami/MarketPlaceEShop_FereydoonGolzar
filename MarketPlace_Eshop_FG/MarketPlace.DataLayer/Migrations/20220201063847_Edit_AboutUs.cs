using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.DataLayer.Migrations
{
    public partial class Edit_AboutUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceSubject1",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceSubject2",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceSubject3",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceSubject4",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceSubject5",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceSubject6",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceSubject1",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ServiceSubject2",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ServiceSubject3",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ServiceSubject4",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ServiceSubject5",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ServiceSubject6",
                table: "AboutUs");
        }
    }
}
