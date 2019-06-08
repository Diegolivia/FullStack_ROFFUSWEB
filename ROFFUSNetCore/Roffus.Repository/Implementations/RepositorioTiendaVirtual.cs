using System.Collections.Generic;
using System.Linq;
using Roffus.Domain;
using Roffus.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Implementations
{
 public class RepositorioTiendaVirtual :IRepositorioTiendaVirtual
    {
        private ApplicationDbContext Context;
        public RepositorioTiendaVirtual(ApplicationDbContext Context)
        {
            this.Context=Context;
        }       

        public bool Eliminar(TiendaVirtual entity)
        {
            Context.TiendasVirtuales.Remove(entity);
            Context.SaveChanges();
                        return true;
        }

        public List<TiendaVirtual> Listar()
        {
            return Context.TiendasVirtuales.ToList();
        }
        public TiendaVirtual ListarPorId(int? id)
        {
            var TiendaVirtual = Context.TiendasVirtuales.FirstOrDefault(x => x.CodTienda == id);
            return TiendaVirtual;

        }

        public bool Insertar(TiendaVirtual entity)
        {
            Context.TiendasVirtuales.Add(entity);
            Context.SaveChanges();
            return true;
        }

        public bool Actualizar(TiendaVirtual entity)
        {
            Context.Entry(entity).State=EntityState.Modified;
            Context.SaveChanges();
                        return true;
        }

  }
}