using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kruger.test.luis.pita.Migrations
{
    public partial class Migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_creacion",
                table: "tbVehiculo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "tbEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    Fecha_ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_salida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbEvento_tbVehiculo_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "tbVehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbParametro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbParametro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCobro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pagado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCobro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbCobro_tbEvento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "tbEvento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbCobro_EventoId",
                table: "tbCobro",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbEvento_VehiculoId",
                table: "tbEvento",
                column: "VehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCobro");

            migrationBuilder.DropTable(
                name: "tbParametro");

            migrationBuilder.DropTable(
                name: "tbEvento");

            migrationBuilder.AlterColumn<string>(
                name: "Fecha_creacion",
                table: "tbVehiculo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
