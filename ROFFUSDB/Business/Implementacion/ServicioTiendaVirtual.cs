using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using Data.Implementacion;

namespace Business.Implementacion
{
   public class ServicioTiendaVirtual: IServicioTiendaVirtual
    {
        private IRepositorioTiendaVirtual repositoriotiendavirtual = new RepositorioTiendaVirtual();
        public bool Insertar(TiendaVirtual t)
        {
            return repositoriotiendavirtual.Insertar(t);
        }
        public bool Actualizar(TiendaVirtual t)
        {
            return repositoriotiendavirtual.Actualizar(t);
        }
        public bool Eliminar(TiendaVirtual t)
        {
            return repositoriotiendavirtual.Eliminar(t);
        }

        public List<TiendaVirtual> Listar()
        {
            return repositoriotiendavirtual.Listar();
        }

        public TiendaVirtual ListarPorId(int? Id)
        {
            return repositoriotiendavirtual.ListarPorId(Id);
        }
    }
}
