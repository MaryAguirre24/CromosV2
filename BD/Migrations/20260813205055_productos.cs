using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BD.Migrations
{
    /// <inheritdoc />
    public partial class productos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OfertasProductos_OfertaId",
                table: "OfertasProductos");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioVenta",
                table: "Productos",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Productos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Productos",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeDescuento",
                table: "Ofertas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "OfertaProducto_OfertaId_ProductoId_UQ",
                table: "OfertasProductos",
                columns: new[] { "OfertaId", "ProductoId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "OfertaProducto_OfertaId_ProductoId_UQ",
                table: "OfertasProductos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PorcentajeDescuento",
                table: "Ofertas");

            migrationBuilder.AlterColumn<int>(
                name: "PrecioVenta",
                table: "Productos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_OfertasProductos_OfertaId",
                table: "OfertasProductos",
                column: "OfertaId");
        }
    }
}
