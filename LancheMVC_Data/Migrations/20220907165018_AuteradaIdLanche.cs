using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LancheMVC_Data.Migrations
{
    public partial class AuteradaIdLanche : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lanches",
                newName: "LancheId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorias",
                newName: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LancheId",
                table: "Lanches",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Categorias",
                newName: "Id");
        }
    }
}
