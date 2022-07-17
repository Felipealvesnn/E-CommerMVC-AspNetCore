using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LancheMVC_Data.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoryName, Descricao)" + "VALUES('Normal', 'Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoryName, Descricao)" + "VALUES('Natural', 'Lanche feito com ingredientes Natural')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE from Categorias");
        }
    }
}
