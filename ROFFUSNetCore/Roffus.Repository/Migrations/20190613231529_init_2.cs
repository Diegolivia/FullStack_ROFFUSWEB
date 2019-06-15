using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Roffus.Repository.Migrations
{
    public partial class init_2 : Migration
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
                name: "Subcategorias",
                columns: table => new
                {
                    codSubCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreSubCategoria = table.Column<string>(nullable: true),
                    CodCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategorias", x => x.codSubCategoria);
                    table.ForeignKey(
                        name: "FK_Subcategorias_Categorias_CodCategoria",
                        column: x => x.CodCategoria,
                        principalTable: "Categorias",
                        principalColumn: "CodCategoria",
                        onDelete: ReferentialAction.Cascade);
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
                    Descripcion = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Icono = table.Column<string>(nullable: true),
                    codSubCategoria = table.Column<int>(nullable: false),
                    CodTienda = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muebles", x => x.CodMueble);
                    table.ForeignKey(
                        name: "FK_Muebles_TiendasVirtuales_CodTienda",
                        column: x => x.CodTienda,
                        principalTable: "TiendasVirtuales",
                        principalColumn: "CodTienda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Muebles_Subcategorias_codSubCategoria",
                        column: x => x.codSubCategoria,
                        principalTable: "Subcategorias",
                        principalColumn: "codSubCategoria",
                        onDelete: ReferentialAction.Cascade);
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
                    CodMueble = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasMuebles", x => x.CodLista);
                    table.ForeignKey(
                        name: "FK_ListasMuebles_Muebles_CodMueble",
                        column: x => x.CodMueble,
                        principalTable: "Muebles",
                        principalColumn: "CodMueble",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    CodPaquete = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombrePaquete = table.Column<string>(nullable: true),
                    CodPlantilla = table.Column<int>(nullable: false),
                    CodUsuario = table.Column<int>(nullable: false),
                    CodLista = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.CodPaquete);
                    table.ForeignKey(
                        name: "FK_Paquetes_ListasMuebles_CodLista",
                        column: x => x.CodLista,
                        principalTable: "ListasMuebles",
                        principalColumn: "CodLista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquetes_Plantillas_CodPlantilla",
                        column: x => x.CodPlantilla,
                        principalTable: "Plantillas",
                        principalColumn: "CodPlantilla",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquetes_Usuarios_CodUsuario",
                        column: x => x.CodUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "CodUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListasMuebles_CodMueble",
                table: "ListasMuebles",
                column: "CodMueble");

            migrationBuilder.CreateIndex(
                name: "IX_Muebles_CodTienda",
                table: "Muebles",
                column: "CodTienda");

            migrationBuilder.CreateIndex(
                name: "IX_Muebles_codSubCategoria",
                table: "Muebles",
                column: "codSubCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_CodLista",
                table: "Paquetes",
                column: "CodLista");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_CodPlantilla",
                table: "Paquetes",
                column: "CodPlantilla");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_CodUsuario",
                table: "Paquetes",
                column: "CodUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategorias_CodCategoria",
                table: "Subcategorias",
                column: "CodCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "ListasMuebles");

            migrationBuilder.DropTable(
                name: "Plantillas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Muebles");

            migrationBuilder.DropTable(
                name: "TiendasVirtuales");

            migrationBuilder.DropTable(
                name: "Subcategorias");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
