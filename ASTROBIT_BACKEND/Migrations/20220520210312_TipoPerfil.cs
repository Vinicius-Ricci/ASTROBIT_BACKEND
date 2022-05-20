using Microsoft.EntityFrameworkCore.Migrations;

namespace ASTROBIT_BACKEND.Migrations
{
    public partial class TipoPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoPerfil",
                table: "USUARIO",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPerfil",
                table: "USUARIO");
        }
    }
}
