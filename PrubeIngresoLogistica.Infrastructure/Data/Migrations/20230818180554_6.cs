using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrubeIngresoLogistica.Infrastructure.Data.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Descuento",
                table: "Entregas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorEnvioTotal",
                table: "Entregas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "ValorEnvioTotal",
                table: "Entregas");
        }
    }
}
