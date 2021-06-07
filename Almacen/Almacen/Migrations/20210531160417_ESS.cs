using Microsoft.EntityFrameworkCore.Migrations;

namespace Almacen.Migrations
{
    public partial class ESS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "ES",
            columns: table => new
            {
                IDMovimiento = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Tipo = table.Column<int>(type: "int", nullable: false),
                cantidad = table.Column<int>(type: "int", nullable: false),
                Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FechaMov = table.Column<int>(type: "datetime", nullable: false),
                BodegaSalida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                BodegaEntrada = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ES", x => x.IDMovimiento);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "ES");
        }
    }
}
