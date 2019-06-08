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
    public class ServicioPaquete : IServicioPaquete
    {
        private IRepositorioPaquete repositorioPaquete = new RepositorioPaquete();
        public bool Insertar(Paquete t)
        {
            return repositorioPaquete.Insertar(t);
        }
        public bool Actualizar(Paquete t)
        {
            return repositorioPaquete.Actualizar(t);
        }
        public bool Eliminar(Paquete t)
        {
            return repositorioPaquete.Eliminar(t);
        }

        public List<Paquete> Listar()
        {
            return repositorioPaquete.Listar();
        }

        public Paquete ListarPorId(int? Id)
        {
            return repositorioPaquete.ListarPorId(Id);
        }
    }
}
