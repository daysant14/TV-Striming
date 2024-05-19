using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneroName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Productora",
                columns: table => new
                {
                    ProductoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoraName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productora", x => x.ProductoraId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    SerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VideoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Actores = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    GeneroPrimarioId = table.Column<int>(type: "int", nullable: false),
                    GeneroSecundarioId = table.Column<int>(type: "int", nullable: false),
                    ProductoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.SerieId);
                    table.ForeignKey(
                        name: "FK_Serie_Genero_GeneroPrimarioId",
                        column: x => x.GeneroPrimarioId,
                        principalTable: "Genero",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Serie_Productora_ProductoraId",
                        column: x => x.ProductoraId,
                        principalTable: "Productora",
                        principalColumn: "ProductoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serie_GeneroPrimarioId",
                table: "Serie",
                column: "GeneroPrimarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_ProductoraId",
                table: "Serie",
                column: "ProductoraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Productora");
        }
    }
}
