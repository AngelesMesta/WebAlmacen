using Microsoft.EntityFrameworkCore.Migrations;

namespace Almacen.Migrations
{
    public partial class TerceraM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Usuario",
              columns: table => new
              {
                  IdUsuario = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Contrasena = table.Column<int>(type: "nvarchar(max)", nullable: false),
                  puesto = table.Column<string>(type: "nvarchar(max)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropTable(
               name: "Usuario");
        }
    }
}
