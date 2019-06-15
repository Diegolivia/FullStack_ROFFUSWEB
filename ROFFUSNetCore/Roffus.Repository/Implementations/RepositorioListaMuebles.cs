using System.Collections.Generic;
using System.Linq;
using Roffus.Domain;
using Roffus.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Implementations
{
 public class RepositorioListaMuebles :IRepositorioListaMuebles
    {
        private ApplicationDbContext Context;
        public RepositorioListaMuebles(ApplicationDbContext Context)
        {
            this.Context=Context;
        }       

        public bool Eliminar(ListaMuebles entity)
        {
            Context.ListasMuebles.Remove(entity);
            Context.SaveChanges();
                        return true;
        }

        public List<ListaMuebles> Listar()
        {
            return Context.ListasMuebles.ToList();
        }
        public ListaMuebles ListarPorId(int? id)
        {
            var ListaMuebles = Context.ListasMuebles.FirstOrDefault(x => x.CodLista == id);
            return ListaMuebles;

        }

        public bool Insertar(ListaMuebles entity)
        {
            Context.ListasMuebles.Add(entity);
            Context.SaveChanges();
            return true;
        }

        public bool Actualizar(ListaMuebles entity)
        {
            Context.Entry(entity).State=EntityState.Modified;
            Context.SaveChanges();
                        return true;
        }

  }
}