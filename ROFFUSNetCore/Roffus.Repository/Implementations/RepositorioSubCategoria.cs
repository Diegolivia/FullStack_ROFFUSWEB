using System.Collections.Generic;
using System.Linq;
using Roffus.Domain;
using Roffus.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Implementations
{
 public class RepositorioSubCategoria :IRepositorioSubCategoria
    {
        private ApplicationDbContext Context;
 
        public RepositorioSubCategoria(ApplicationDbContext Context)
        {
            this.Context=Context;
        }       

        public bool Eliminar(SubCategoria entity)
        {
            Context.SubCategorias.Remove(entity);
            Context.SaveChanges();
                        return true;
        }

        public List<SubCategoria> Listar()
        {
            return Context.SubCategorias.ToList();
        }
        public SubCategoria ListarPorId(int? id)
        {
            var SubCategoria = Context.SubCategorias.FirstOrDefault(x => x.CodSubCategoria == id);
            return SubCategoria;

        }

        public bool Insertar(SubCategoria entity)
        {
            Context.SubCategorias.Add(entity);
            Context.SaveChanges();
            return true;
        }

        public bool Actualizar(SubCategoria entity)
        {
            Context.Entry(entity).State=EntityState.Modified;
            Context.SaveChanges();
             return true;
        }

  }
}