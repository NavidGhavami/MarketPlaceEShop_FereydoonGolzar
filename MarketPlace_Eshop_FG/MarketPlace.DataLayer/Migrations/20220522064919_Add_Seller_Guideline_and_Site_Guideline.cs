using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.DataLayer.Migrations
{
    public partial class Add_Seller_Guideline_and_Site_Guideline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SellerGuidelines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTitle = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    AnswerTitle = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerGuidelines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteGuidelines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteGuidelines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerGuidelines");

            migrationBuilder.DropTable(
                name: "SiteGuidelines");
        }
    }
}
