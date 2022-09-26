using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LancheMVC_Data.Migrations
{
    public partial class pedidosEDite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens");

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "PedidoDetalhes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "PedidoDetalhes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoLanche",
                table: "PedidoDetalhes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "LancheId",
                table: "CarrinhoCompraItens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "LancheId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "PedidoDetalhes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "PedidoDetalhes");

            migrationBuilder.DropColumn(
                name: "PrecoLanche",
                table: "PedidoDetalhes");

            migrationBuilder.AlterColumn<int>(
                name: "LancheId",
                table: "CarrinhoCompraItens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "LancheId");
        }
    }
}
