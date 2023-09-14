using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaOrdenadoresDB.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    NumeroDeSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Calor = table.Column<int>(type: "int", nullable: false),
                    Almacenamiento = table.Column<long>(type: "bigint", nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordenador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDeSerie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Calor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenadorComponente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponenteId = table.Column<int>(type: "int", nullable: false),
                    OrdenadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenadorComponente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenadorComponente_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenadorComponente_Ordenador_OrdenadorId",
                        column: x => x.OrdenadorId,
                        principalTable: "Ordenador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenadorPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    OrdenadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenadorPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenadorPedido_Ordenador_OrdenadorId",
                        column: x => x.OrdenadorId,
                        principalTable: "Ordenador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenadorPedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Almacenamiento", "Calor", "Categoria", "Description", "NumeroDeSerie", "Precio", "UnidadMedida" },
                values: new object[,]
                {
                    { 1, 9L, 10, 0, "Procesador intel i7", "789-XCS", 134, "Cores" },
                    { 2, 10L, 12, 0, "Procesador intel i7", "789-XCD", 138, "Cores" },
                    { 3, 11L, 22, 0, "Procesador intel i7", "789-XCT", 138, "Cores" },
                    { 4, 10L, 30, 0, "Procesador intel i7", "797-X", 78, "Cores" },
                    { 5, 29L, 30, 0, "Procesador intel i7", "797-X2", 178, "Cores" },
                    { 6, 34L, 60, 0, "Procesador intel i7", "797-X3", 278, "Cores" },
                    { 7, 4096L, 10, 1, "Banco de Memoria SDRAM", "879-FH", 100, "Bytes" },
                    { 8, 1000L, 15, 1, "Banco de Memoria SDRAM", "879-FH-L", 125, "Bytes" },
                    { 9, 2000L, 24, 1, "Banco de Memoria SDRAM", "879-FH-T", 150, "Bytes" },
                    { 10, 500000L, 10, 2, "DiscoDuro SanDisk", "789-XX", 50, "Bytes" },
                    { 11, 1000000L, 29, 2, "DiscoDuro SanDisk", "789-XX-2", 90, "Bytes" },
                    { 12, 2000000L, 39, 2, "DiscoDuro SanDisk", "789-XX-3", 128, "Bytes" },
                    { 13, 250000L, 35, 2, "DiscoMecanico Patatin", "788-FG", 37, "Bytes" },
                    { 14, 250000L, 35, 2, "DiscoMecanico Patatin", "788-FG-2", 67, "Bytes" },
                    { 15, 250000L, 35, 2, "DiscoMecanico Patatin", "788-FG-3", 97, "Bytes" },
                    { 16, 9000000L, 10, 2, "Disco Externo Sam", "1789-XCS", 134, "Bytes" },
                    { 17, 10000000L, 12, 2, "Disco Externo Sam", "1789-XCD", 138, "Bytes" },
                    { 18, 11000000L, 22, 2, "Disco Externo Sam", "1789-XCT", 140, "Bytes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenadorComponente_ComponenteId",
                table: "OrdenadorComponente",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenadorComponente_OrdenadorId",
                table: "OrdenadorComponente",
                column: "OrdenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenadorPedido_OrdenadorId",
                table: "OrdenadorPedido",
                column: "OrdenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenadorPedido_PedidoId",
                table: "OrdenadorPedido",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenadorComponente");

            migrationBuilder.DropTable(
                name: "OrdenadorPedido");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Ordenador");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
