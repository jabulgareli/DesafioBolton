using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IMPORT_PROFILE",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurrentPage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMPORT_PROFILE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NFE",
                columns: table => new
                {
                    AccessKey = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFE", x => x.AccessKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMPORT_PROFILE");

            migrationBuilder.DropTable(
                name: "NFE");
        }
    }
}
