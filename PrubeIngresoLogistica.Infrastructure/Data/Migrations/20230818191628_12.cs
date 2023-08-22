using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrubeIngresoLogistica.Infrastructure.Data.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_MediosTransportes_TipoMedioTransporteId",
                table: "Entregas");

            migrationBuilder.RenameColumn(
                name: "TipoMedioTransporteId",
                table: "Entregas",
                newName: "MedioTransporteId");

            migrationBuilder.RenameIndex(
                name: "IX_Entregas_TipoMedioTransporteId",
                table: "Entregas",
                newName: "IX_Entregas_MedioTransporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_MediosTransportes_MedioTransporteId",
                table: "Entregas",
                column: "MedioTransporteId",
                principalTable: "MediosTransportes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_MediosTransportes_MedioTransporteId",
                table: "Entregas");

            migrationBuilder.RenameColumn(
                name: "MedioTransporteId",
                table: "Entregas",
                newName: "TipoMedioTransporteId");

            migrationBuilder.RenameIndex(
                name: "IX_Entregas_MedioTransporteId",
                table: "Entregas",
                newName: "IX_Entregas_TipoMedioTransporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_MediosTransportes_TipoMedioTransporteId",
                table: "Entregas",
                column: "TipoMedioTransporteId",
                principalTable: "MediosTransportes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
