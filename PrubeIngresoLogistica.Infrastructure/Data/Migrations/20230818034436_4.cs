using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrubeIngresoLogistica.Infrastructure.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LugarDestinoId",
                table: "Entregas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_LugarDestinoId",
                table: "Entregas",
                column: "LugarDestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_LugaresDestinos_LugarDestinoId",
                table: "Entregas",
                column: "LugarDestinoId",
                principalTable: "LugaresDestinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_LugaresDestinos_LugarDestinoId",
                table: "Entregas");

            migrationBuilder.DropIndex(
                name: "IX_Entregas_LugarDestinoId",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "LugarDestinoId",
                table: "Entregas");
        }
    }
}
