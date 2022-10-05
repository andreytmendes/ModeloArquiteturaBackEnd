using Microsoft.EntityFrameworkCore.Migrations;

namespace Lideranca.Data.Data.Migrations
{
    public partial class Added_Observacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                schema: "liderancadb",
                table: "Test",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                schema: "liderancadb",
                table: "Test");
        }
    }
}
