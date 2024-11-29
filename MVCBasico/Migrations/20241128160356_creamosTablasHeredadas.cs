using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasico.Migrations
{
    /// <inheritdoc />
    public partial class creamosTablasHeredadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular_memoriaRam",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Celular_procesador",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "lectorDisco",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "memoriaRam",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "potenciaWatts",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "procesador",
                table: "Productos");

            migrationBuilder.CreateTable(
                name: "Auriculares",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    potenciaWatts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auriculares", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Auriculares_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Celulares",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    procesador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memoriaRam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celulares", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Celulares_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Computadoras",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    procesador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memoriaRam = table.Column<int>(type: "int", nullable: false),
                    lectorDisco = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computadoras", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Computadoras_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auriculares");

            migrationBuilder.DropTable(
                name: "Celulares");

            migrationBuilder.DropTable(
                name: "Computadoras");

            migrationBuilder.AddColumn<int>(
                name: "Celular_memoriaRam",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular_procesador",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Productos",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "lectorDisco",
                table: "Productos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "memoriaRam",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "potenciaWatts",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "procesador",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
