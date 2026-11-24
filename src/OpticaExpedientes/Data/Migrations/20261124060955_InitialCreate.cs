using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticaExpedientes.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Domicilio = table.Column<string>(type: "TEXT", nullable: true),
                    Colonia = table.Column<string>(type: "TEXT", nullable: true),
                    Ciudad = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Ocupacion = table.Column<string>(type: "TEXT", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Folio = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Examino = table.Column<string>(type: "TEXT", nullable: true),
                    Edad = table.Column<int>(type: "INTEGER", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "TEXT", nullable: true),
                    SaludGeneral = table.Column<string>(type: "TEXT", nullable: true),
                    Alergias = table.Column<string>(type: "TEXT", nullable: true),
                    AntecedentesOftalmologicos = table.Column<string>(type: "TEXT", nullable: true),
                    PrescripcionActualTipo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PrescLejosOD = table.Column<string>(type: "TEXT", nullable: true),
                    PrescLejosOI = table.Column<string>(type: "TEXT", nullable: true),
                    PrescAddOD = table.Column<string>(type: "TEXT", nullable: true),
                    PrescAddOI = table.Column<string>(type: "TEXT", nullable: true),
                    PrescLcOD = table.Column<string>(type: "TEXT", nullable: true),
                    PrescLcOI = table.Column<string>(type: "TEXT", nullable: true),
                    PrescAvOD = table.Column<string>(type: "TEXT", nullable: true),
                    PrescAvOI = table.Column<string>(type: "TEXT", nullable: true),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true),
                    AvOD = table.Column<string>(type: "TEXT", nullable: true),
                    AvOI = table.Column<string>(type: "TEXT", nullable: true),
                    KOD = table.Column<string>(type: "TEXT", nullable: true),
                    KOI = table.Column<string>(type: "TEXT", nullable: true),
                    EsquiascopiaOD = table.Column<string>(type: "TEXT", nullable: true),
                    EsquiascopiaOI = table.Column<string>(type: "TEXT", nullable: true),
                    EstenopeicoOD = table.Column<string>(type: "TEXT", nullable: true),
                    EstenopeicoOI = table.Column<string>(type: "TEXT", nullable: true),
                    SaludOcularOD = table.Column<string>(type: "TEXT", nullable: true),
                    SaludOcularOI = table.Column<string>(type: "TEXT", nullable: true),
                    AutorrefLejosOD = table.Column<string>(type: "TEXT", nullable: true),
                    AutorrefLejosOI = table.Column<string>(type: "TEXT", nullable: true),
                    AutorrefAddOD = table.Column<string>(type: "TEXT", nullable: true),
                    AutorrefAddOI = table.Column<string>(type: "TEXT", nullable: true),
                    PruebasComplementarias = table.Column<string>(type: "TEXT", nullable: true),
                    RxTotalLejosOD = table.Column<string>(type: "TEXT", nullable: true),
                    RxTotalLejosOI = table.Column<string>(type: "TEXT", nullable: true),
                    RxTotalAddOD = table.Column<string>(type: "TEXT", nullable: true),
                    RxTotalAddOI = table.Column<string>(type: "TEXT", nullable: true),
                    RxFinalLejosOD = table.Column<string>(type: "TEXT", nullable: true),
                    RxFinalLejosOI = table.Column<string>(type: "TEXT", nullable: true),
                    RxFinalAddOD = table.Column<string>(type: "TEXT", nullable: true),
                    RxFinalAddOI = table.Column<string>(type: "TEXT", nullable: true),
                    RxFinalAvOD = table.Column<string>(type: "TEXT", nullable: true),
                    RxFinalAvOI = table.Column<string>(type: "TEXT", nullable: true),
                    Dx = table.Column<string>(type: "TEXT", nullable: true),
                    DistanciaInterpupilar = table.Column<string>(type: "TEXT", nullable: true),
                    AlturaOptica = table.Column<string>(type: "TEXT", nullable: true),
                    LcRx = table.Column<string>(type: "TEXT", nullable: true),
                    LcCb = table.Column<string>(type: "TEXT", nullable: true),
                    LcDiametro = table.Column<string>(type: "TEXT", nullable: true),
                    LcTipoMarca = table.Column<string>(type: "TEXT", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expedientes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidosArmazon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExpedienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FechaPedido = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PrecioArmazon = table.Column<decimal>(type: "TEXT", nullable: false),
                    PrecioPlastico = table.Column<decimal>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    FechaEntrega = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualizadoEn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosArmazon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosArmazon_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_Fecha",
                table: "Expedientes",
                column: "Fecha");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_Folio",
                table: "Expedientes",
                column: "Folio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_PacienteId",
                table: "Expedientes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosArmazon_Estado",
                table: "PedidosArmazon",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosArmazon_ExpedienteId",
                table: "PedidosArmazon",
                column: "ExpedienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidosArmazon_FechaEntrega",
                table: "PedidosArmazon",
                column: "FechaEntrega");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosArmazon");

            migrationBuilder.DropTable(
                name: "Expedientes");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
