using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppWebPedidos.Migrations
{
    /// <inheritdoc />
    public partial class CrearPlato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plato",
                columns: table => new
                {
                    id_plato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    imagen_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    disponible = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plato", x => x.id_plato);
                    table.ForeignKey(
                        name: "FK_plato_categoria_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id_categoria",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_plato_id_categoria",
                table: "plato",
                column: "id_categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plato");
        }
    }
}
