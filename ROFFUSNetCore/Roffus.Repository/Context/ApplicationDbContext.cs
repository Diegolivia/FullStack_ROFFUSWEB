using Roffus.Domain;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Context
{
    public class ApplicationDbContext:DbContext
    {   
        public DbSet<Categoria> Categorias {get;set;}
        public DbSet<ListaMuebles> ListasMuebles {get;set;}
        public DbSet<Mueble> Muebles {get;set;}
        public DbSet<Paquete> Paquetes {get;set;}     
        public DbSet<Plantilla> Plantillas {get;set;}   
        public DbSet<TiendaVirtual> TiendasVirtuales {get;set;}
        public DbSet<Usuario> Usuarios {get;set;}   
        public DbSet<Subcategoria> Subcategorias {get;set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) {}
    }
}