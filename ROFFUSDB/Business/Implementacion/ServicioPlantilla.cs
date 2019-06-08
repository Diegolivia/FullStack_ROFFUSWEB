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
   public class ServicioPlantilla : IServicioPlantilla
    {
        private IRepositorioPlantilla repositorioplantilla = new RepositorioPlantilla();
        public bool Insertar(Plantilla t)
        {
            return repositorioplantilla.Insertar(t);
        }
        public bool Actualizar(Plantilla t)
        {
            return repositorioplantilla.Actualizar(t);
        }
        public bool Eliminar(Plantilla t)
        {
            return repositorioplantilla.Eliminar(t);
        }

        public List<Plantilla> Listar()
        {
            return repositorioplantilla.Listar();
        }

        public Plantilla ListarPorId(int? Id)
        {
            return repositorioplantilla.ListarPorId(Id);
        }
    }
}
