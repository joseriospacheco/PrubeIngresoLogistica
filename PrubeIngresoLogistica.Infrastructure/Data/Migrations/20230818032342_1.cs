using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrubeIngresoLogistica.Infrastructure.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoProductoId",
                table: "Entregas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_TipoProductoId",
                table: "Entregas",
                column: "TipoProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_TipoProductos_TipoProductoId",
                table: "Entregas",
                column: "TipoProductoId",
                principalTable: "TipoProductos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_TipoProductos_TipoProductoId",
                table: "Entregas");

            migrationBuilder.DropIndex(
                name: "IX_Entregas_TipoProductoId",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "TipoProductoId",
                table: "Entregas");
        }
    }
}
