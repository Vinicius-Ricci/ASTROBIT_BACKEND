using Microsoft.EntityFrameworkCore.Migrations;

namespace ASTROBIT_BACKEND.Migrations
{
    public partial class changePropId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioMoeda_Moeda_MoedaId",
                table: "UsuarioMoeda");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioMoeda_USUARIO_UsuarioId",
                table: "UsuarioMoeda");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioMoeda_MoedaId",
                table: "UsuarioMoeda");

            migrationBuilder.DropColumn(
                name: "Moeda_Id",
                table: "UsuarioMoeda");

            migrationBuilder.DropColumn(
                name: "Usuario_Id",
                table: "UsuarioMoeda");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "UsuarioMoeda",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoedaId",
                table: "UsuarioMoeda",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoedaId1",
                table: "UsuarioMoeda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMoeda_MoedaId1",
                table: "UsuarioMoeda",
                column: "MoedaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioMoeda_Moeda_MoedaId1",
                table: "UsuarioMoeda",
                column: "MoedaId1",
                principalTable: "Moeda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioMoeda_USUARIO_UsuarioId",
                table: "UsuarioMoeda",
                column: "UsuarioId",
                principalTable: "USUARIO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioMoeda_Moeda_MoedaId1",
                table: "UsuarioMoeda");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioMoeda_USUARIO_UsuarioId",
                table: "UsuarioMoeda");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioMoeda_MoedaId1",
                table: "UsuarioMoeda");

            migrationBuilder.DropColumn(
                name: "MoedaId1",
                table: "UsuarioMoeda");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "UsuarioMoeda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MoedaId",
                table: "UsuarioMoeda",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Moeda_Id",
                table: "UsuarioMoeda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Usuario_Id",
                table: "UsuarioMoeda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMoeda_MoedaId",
                table: "UsuarioMoeda",
                column: "MoedaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioMoeda_Moeda_MoedaId",
                table: "UsuarioMoeda",
                column: "MoedaId",
                principalTable: "Moeda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioMoeda_USUARIO_UsuarioId",
                table: "UsuarioMoeda",
                column: "UsuarioId",
                principalTable: "USUARIO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
