using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrubeIngresoLogistica.Infrastructure.Data.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacaVehiculo",
                table: "Entregas");

            migrationBuilder.AddColumn<int>(
                name: "TipoMedioTransporte",
                table: "Entregas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoMedioTransporteId",
                table: "Entregas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMedioTransporte",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "TipoMedioTransporteId",
                table: "Entregas");

            migrationBuilder.AddColumn<string>(
                name: "PlacaVehiculo",
                table: "Entregas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
