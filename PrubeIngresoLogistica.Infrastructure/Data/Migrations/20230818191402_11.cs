using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrubeIngresoLogistica.Infrastructure.Data.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMedioTransporte",
                table: "Entregas");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_TipoMedioTransporteId",
                table: "Entregas",
                column: "TipoMedioTransporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_MediosTransportes_TipoMedioTransporteId",
                table: "Entregas",
                column: "TipoMedioTransporteId",
                principalTable: "MediosTransportes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_MediosTransportes_TipoMedioTransporteId",
                table: "Entregas");

            migrationBuilder.DropIndex(
                name: "IX_Entregas_TipoMedioTransporteId",
                table: "Entregas");

            migrationBuilder.AddColumn<int>(
                name: "TipoMedioTransporte",
                table: "Entregas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
