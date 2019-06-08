using System.Collections.Generic;
using System.Linq;
using Roffus.Domain;
using Roffus.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Implementations
{
 public class RepositorioPaquete :IRepositorioPaquete
    {
        private ApplicationDbContext Context;
        public RepositorioPaquete(ApplicationDbContext Context)
        {
            this.Context=Context;
        }       

        public bool Eliminar(Paquete entity)
        {
            Context.Paquetes.Remove(entity);
            Context.SaveChanges();
            return true;
        }

        public List<Paquete> Listar()
        {
            return Context.Paquetes.ToList();
        }
        public Paquete ListarPorId(int? id)
        {
            var Paquete = Context.Paquetes.FirstOrDefault(x => x.CodPaquete == id);
            return Paquete;

        }

        public bool Insertar(Paquete entity)
        {
            Context.Paquetes.Add(entity);
            Context.SaveChanges();
            return true;
        }

        public bool Actualizar(Paquete entity)
        {
            Context.Entry(entity).State=EntityState.Modified;
            Context.SaveChanges();
                        return true;
        }

  }
}