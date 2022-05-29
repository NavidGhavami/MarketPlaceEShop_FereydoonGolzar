using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.DataLayer.Migrations
{
    public partial class Add_BankAccount_Information_To_Sellers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Sellers",
                newName: "BankAccountShabaNumber");

            migrationBuilder.AddColumn<string>(
                name: "BankAccountCardNumber",
                table: "Sellers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                table: "Sellers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountCardNumber",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                table: "Sellers");

            migrationBuilder.RenameColumn(
                name: "BankAccountShabaNumber",
                table: "Sellers",
                newName: "Logo");
        }
    }
}
