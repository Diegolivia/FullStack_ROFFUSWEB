using System.Collections.Generic;
using System.Linq;
using Roffus.Domain;
using Roffus.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Implementations
{
    public class RepositorioMueble : IRepositorioMueble
    {
        private ApplicationDbContext Context;
        public RepositorioMueble(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public bool Insertar(Mueble entity)
        {
            Context.Muebles.Add(entity);
            Context.SaveChanges();
            return true;
        }

        public bool Actualizar(Mueble entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }

         public List<Mueble> Filtrador(Mueble entity)
        {
            var Mueblee = Context.Muebles
                                    .Where(
                                        x => x.Subcategoria.nombreSubCategoria.Equals(entity.Subcategoria.nombreSubCategoria
                                        ))
                                        .ToList();
            return Mueblee;
        }

        public bool Eliminar(Mueble entity)
        {
            Context.Muebles.Remove(entity);
            Context.SaveChanges();
            return true;
        }

        public List<Mueble> Listar()
        {
            return Context.Muebles.ToList();
        }
        public Mueble ListarPorId(int? id)
        {
            var Mueble = Context.Muebles.FirstOrDefault(x => x.CodMueble == id);
            return Mueble;

        }

        public List<Mueble> ListBySubCategory(string subcat)
        {
            var Mueble = Context.Muebles.Where(X => X.Subcategoria.nombreSubCategoria.Equals(subcat)).ToList();
            return Mueble;
        }
    }
}