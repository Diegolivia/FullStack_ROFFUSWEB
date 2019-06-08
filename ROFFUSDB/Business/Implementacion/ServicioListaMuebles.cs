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
    public class ServicioListaMuebles : IServicioListaMuebles
    {
        private IRepositorioListaMuebles repositoriolistaMuebles = new RepositorioListaMuebles();
        public bool Insertar(ListaMuebles t)
        {
            return repositoriolistaMuebles.Insertar(t);
        }
        public bool Actualizar(ListaMuebles t)
        {
            return repositoriolistaMuebles.Actualizar(t);
        }
        public bool Eliminar(ListaMuebles t)
        {
            return repositoriolistaMuebles.Eliminar(t);
        }
        public List<ListaMuebles> Listar()
        {
            return repositoriolistaMuebles.Listar();
        }
        public ListaMuebles ListarPorId(int? Id)
        {
            return repositoriolistaMuebles.ListarPorId(Id);
        }

    }
}
