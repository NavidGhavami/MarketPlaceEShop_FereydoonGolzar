using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.DataLayer.Migrations
{
    public partial class Add_AboutUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUsText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUsImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Service1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");
        }
    }
}
