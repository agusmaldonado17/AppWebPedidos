using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppWebPedidos.Migrations
{
    /// <inheritdoc />
    public partial class CrearPedidoYDetallePedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre_cliente = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    telefono = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    direccion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estado = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.id_pedido);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_pedido",
                columns: table => new
                {
                    id_detalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    id_plato = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    observacion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_pedido", x => x.id_detalle);
                    table.ForeignKey(
                        name: "FK_detalle_pedido_pedido_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "pedido",
                        principalColumn: "id_pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_pedido_plato_id_plato",
                        column: x => x.id_plato,
                        principalTable: "plato",
                        principalColumn: "id_plato",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_pedido_id_pedido",
                table: "detalle_pedido",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_pedido_id_plato",
                table: "detalle_pedido",
                column: "id_plato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_pedido");

            migrationBuilder.DropTable(
                name: "pedido");
        }
    }
}
