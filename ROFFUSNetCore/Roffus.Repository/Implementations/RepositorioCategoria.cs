using System.Collections.Generic;
using System.Linq;
using Roffus.Domain;
using Roffus.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Implementations
{
 public class RepositorioCategoria :IRepositorioCategoria
    {
        private ApplicationDbContext Context;
 
        public RepositorioCategoria(ApplicationDbContext Context)
        {
            this.Context=Context;
        }       

        public bool Eliminar(Categoria entity)
        {
            Context.Categorias.Remove(entity);
            Context.SaveChanges();
                        return true;
        }

        public List<Categoria> Listar()
        {
            return Context.Categorias.ToList();
        }
        public Categoria ListarPorId(int? id)
        {
            var Categoria = Context.Categorias.FirstOrDefault(x => x.CodCategoria == id);
            return Categoria;

        }

        public bool Insertar(Categoria entity)
        {
            Context.Categorias.Add(entity);
            Context.SaveChanges();
            return true;
        }

        public bool Actualizar(Categoria entity)
        {
            Context.Entry(entity).State=EntityState.Modified;
            Context.SaveChanges();
             return true;
        }

  }
}