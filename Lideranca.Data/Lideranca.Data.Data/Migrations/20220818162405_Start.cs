using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lideranca.Data.Data.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "liderancadb");

            migrationBuilder.CreateTable(
                name: "Test",
                schema: "liderancadb",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test",
                schema: "liderancadb");
        }
    }
}
