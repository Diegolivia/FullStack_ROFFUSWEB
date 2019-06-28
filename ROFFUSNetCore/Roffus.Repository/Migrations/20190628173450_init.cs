using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Roffus.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CodCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCategoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CodCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Plantillas",
                columns: table => new
                {
                    CodPlantilla = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Diseño = table.Column<string>(nullable: true),
                    Alto = table.Column<double>(nullable: false),
                    Ancho = table.Column<double>(nullable: false),
                    Largo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantillas", x => x.CodPlantilla);
                });

            migrationBuilder.CreateTable(
                name: "SubCategorias",
                columns: table => new
                {
                    CodSubCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreSubCategoria = table.Column<string>(nullable: true),
                    CodCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategorias", x => x.CodSubCategoria);
                });

            migrationBuilder.CreateTable(
                name: "TiendasVirtuales",
                columns: table => new
                {
                    CodTienda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreTienda = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiendasVirtuales", x => x.CodTienda);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    FNacimiento = table.Column<DateTime>(nullable: false),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Muebles",
                columns: table => new
                {
                    CodMueble = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreMueble = table.Column<string>(nullable: true),
                    Alto = table.Column<double>(nullable: false),
                    Ancho = table.Column<double>(nullable: false),
                    Largo = table.Column<double>(nullable: false),
                    CodTienda1 = table.Column<int>(nullable: true),
                    CodSubCategoria1 = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Icono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muebles", x => x.CodMueble);
                    table.ForeignKey(
                        name: "FK_Muebles_SubCategorias_CodSubCategoria1",
                        column: x => x.CodSubCategoria1,
                        principalTable: "SubCategorias",
                        principalColumn: "CodSubCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Muebles_TiendasVirtuales_CodTienda1",
                        column: x => x.CodTienda1,
                        principalTable: "TiendasVirtuales",
                        principalColumn: "CodTienda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListasMuebles",
                columns: table => new
                {
                    CodLista = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreLista = table.Column<string>(nullable: true),
                    CoordX = table.Column<double>(nullable: false),
                    CoordY = table.Column<double>(nullable: false),
                    Rotacion = table.Column<double>(nullable: false),
                    CodMueble1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasMuebles", x => x.CodLista);
                    table.ForeignKey(
                        name: "FK_ListasMuebles_Muebles_CodMueble1",
                        column: x => x.CodMueble1,
                        principalTable: "Muebles",
                        principalColumn: "CodMueble",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    CodPaquete = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodPlantilla1 = table.Column<int>(nullable: true),
                    CodUsuario1 = table.Column<int>(nullable: true),
                    NombreListaCodLista = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.CodPaquete);
                    table.ForeignKey(
                        name: "FK_Paquetes_Plantillas_CodPlantilla1",
                        column: x => x.CodPlantilla1,
                        principalTable: "Plantillas",
                        principalColumn: "CodPlantilla",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paquetes_Usuarios_CodUsuario1",
                        column: x => x.CodUsuario1,
                        principalTable: "Usuarios",
                        principalColumn: "CodUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paquetes_ListasMuebles_NombreListaCodLista",
                        column: x => x.NombreListaCodLista,
                        principalTable: "ListasMuebles",
                        principalColumn: "CodLista",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListasMuebles_CodMueble1",
                table: "ListasMuebles",
                column: "CodMueble1");

            migrationBuilder.CreateIndex(
                name: "IX_Muebles_CodSubCategoria1",
                table: "Muebles",
                column: "CodSubCategoria1");

            migrationBuilder.CreateIndex(
                name: "IX_Muebles_CodTienda1",
                table: "Muebles",
                column: "CodTienda1");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_CodPlantilla1",
                table: "Paquetes",
                column: "CodPlantilla1");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_CodUsuario1",
                table: "Paquetes",
                column: "CodUsuario1");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_NombreListaCodLista",
                table: "Paquetes",
                column: "NombreListaCodLista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Plantillas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ListasMuebles");

            migrationBuilder.DropTable(
                name: "Muebles");

            migrationBuilder.DropTable(
                name: "SubCategorias");

            migrationBuilder.DropTable(
                name: "TiendasVirtuales");
        }
    }
}
