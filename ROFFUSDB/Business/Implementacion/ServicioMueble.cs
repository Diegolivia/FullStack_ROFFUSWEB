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
    public class ServicioMueble : IServicioMueble
    {
        private IRepositorioMueble repositorioMueble = new RepositorioMueble();
        public bool Insertar(Mueble t)
        {
            return repositorioMueble.Insertar(t);
        }
        public bool Actualizar(Mueble t)
        {
            return repositorioMueble.Actualizar(t);
        }
        public bool Eliminar(Mueble t)
        {
            return repositorioMueble.Eliminar(t);
        }

        public List<Mueble> Listar()
        {
            return repositorioMueble.Listar();
        }

        public Mueble ListarPorId(int? Id)
        {
            return repositorioMueble.ListarPorId(Id);
        }
    }
}
