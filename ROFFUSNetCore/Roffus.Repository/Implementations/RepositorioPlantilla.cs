using System.Collections.Generic;
using System.Linq;
using Roffus.Domain;
using Roffus.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Implementations
{
 public class RepositorioPlantilla :IRepositorioPlantilla
    {
        private ApplicationDbContext Context;
        public RepositorioPlantilla(ApplicationDbContext Context)
        {
            this.Context=Context;
        }       

        public bool Eliminar(Plantilla entity)
        {
            Context.Plantillas.Remove(entity);
            Context.SaveChanges();
                        return true;
        }

        public List<Plantilla> Listar()
        {
            return Context.Plantillas.ToList();
        }
        public Plantilla ListarPorId(int? id)
        {
            var Plantilla = Context.Plantillas.FirstOrDefault(x => x.CodPlantilla == id);
            return Plantilla;

        }

        public bool Insertar(Plantilla entity)
        {
            Context.Plantillas.Add(entity);
            Context.SaveChanges();
            return true;
        }

        public bool Actualizar(Plantilla entity)
        {
            Context.Entry(entity).State=EntityState.Modified;
            Context.SaveChanges();
                        return true;
        }

  }
}