using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaBlogsPersonales.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class migracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMBRE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SLUG = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUARIO_CREACION = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FECHA_ACTUALIZACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_ACTUALIZACION = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    REGISTRO_ELIMINADO = table.Column<bool>(type: "bit", nullable: false),
                    FECHA_ELIMINACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_ELIMINACION = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ETIQUETA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMBRE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SLUG = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUARIO_CREACION = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FECHA_ACTUALIZACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_ACTUALIZACION = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    REGISTRO_ELIMINADO = table.Column<bool>(type: "bit", nullable: false),
                    FECHA_ELIMINACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_ELIMINACION = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETIQUETA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ARTICULO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TITULO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CONTENIDO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RESUMEN = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    AUTOR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ID_CATEGORIA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ESTADO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SLUG_IMAGEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NUMERO_VISITAS = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    COMENTARIOS_HABILITADOS = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUARIO_CREACION = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FECHA_ACTUALIZACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_ACTUALIZACION = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    REGISTRO_ELIMINADO = table.Column<bool>(type: "bit", nullable: false),
                    FECHA_ELIMINACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_ELIMINACION = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICULO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ARTICULO_CATEGORIA_ID_CATEGORIA",
                        column: x => x.ID_CATEGORIA,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ARTICULO_ETIQUETA",
                columns: table => new
                {
                    ID_ARTICULO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_ETIQUETA = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICULO_ETIQUETA", x => new { x.ID_ARTICULO, x.ID_ETIQUETA });
                    table.ForeignKey(
                        name: "FK_ARTICULO_ETIQUETA_ARTICULO_ID_ARTICULO",
                        column: x => x.ID_ARTICULO,
                        principalTable: "ARTICULO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ARTICULO_ETIQUETA_ETIQUETA_ID_ETIQUETA",
                        column: x => x.ID_ETIQUETA,
                        principalTable: "ETIQUETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARTICULO_ID_CATEGORIA",
                table: "ARTICULO",
                column: "ID_CATEGORIA");

            migrationBuilder.CreateIndex(
                name: "IX_ARTICULO_ETIQUETA_ID_ETIQUETA",
                table: "ARTICULO_ETIQUETA",
                column: "ID_ETIQUETA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARTICULO_ETIQUETA");

            migrationBuilder.DropTable(
                name: "ARTICULO");

            migrationBuilder.DropTable(
                name: "ETIQUETA");

            migrationBuilder.DropTable(
                name: "CATEGORIA");
        }
    }
}
