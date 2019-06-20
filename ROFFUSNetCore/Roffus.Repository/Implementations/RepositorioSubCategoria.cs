using System.Collections.Generic;
using System.Linq;
using Roffus.Domain;
using Roffus.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Implementations
{
    public class RepositorioSubCategoria:IRepositorioSubCategoria
    {
        private ApplicationDbContext context;

        public RepositorioSubCategoria(ApplicationDbContext context){
            this.context=context;
        }

        public bool Insertar(Subcategoria entity){
            context.Subcategorias.Add(entity);
            context.SaveChanges();
            return true;
        }
        public bool Actualizar(Subcategoria entity){
            context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
            return true;
        }
        public bool Eliminar(Subcategoria entity){
            context.Subcategorias.Remove(entity);
            context.SaveChanges();
            return true;
        }
        public List<Subcategoria> Listar(){
            return context.Subcategorias.ToList();
        }
        public Subcategoria ListarPorId(int? Id){
            var SubCategoria=context.Subcategorias.FirstOrDefault(x => x.codSubCategoria == Id);
            return SubCategoria;
        }
         public List<Subcategoria> ListByCategory(string cat){
            var SubCategoria=context.Subcategorias.Where(X => X.Categoria.NombreCategoria.Equals(cat)).ToList();
            return SubCategoria;
        }

    }
}