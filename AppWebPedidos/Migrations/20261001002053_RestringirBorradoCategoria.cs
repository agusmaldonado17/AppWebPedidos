using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWebPedidos.Migrations
{
    /// <inheritdoc />
    public partial class RestringirBorradoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plato_categoria_id_categoria",
                table: "plato");

            migrationBuilder.AddForeignKey(
                name: "FK_plato_categoria_id_categoria",
                table: "plato",
                column: "id_categoria",
                principalTable: "categoria",
                principalColumn: "id_categoria",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plato_categoria_id_categoria",
                table: "plato");

            migrationBuilder.AddForeignKey(
                name: "FK_plato_categoria_id_categoria",
                table: "plato",
                column: "id_categoria",
                principalTable: "categoria",
                principalColumn: "id_categoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
