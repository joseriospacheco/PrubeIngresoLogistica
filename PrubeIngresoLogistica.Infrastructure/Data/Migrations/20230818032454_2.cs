using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrubeIngresoLogistica.Infrastructure.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Entregas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_ClienteId",
                table: "Entregas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_Clientes_ClienteId",
                table: "Entregas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_Clientes_ClienteId",
                table: "Entregas");

            migrationBuilder.DropIndex(
                name: "IX_Entregas_ClienteId",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Entregas");
        }
    }
}
