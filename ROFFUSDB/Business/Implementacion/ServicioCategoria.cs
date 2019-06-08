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
    public class ServicioCategoria : IServicioCategoria
    {
        private IRepositorioCategoria repositoriocategoria = new RepositorioCategoria();
        public bool Insertar(Categoria t)
        {
            return repositoriocategoria.Insertar(t);
        }
        public bool Actualizar(Categoria t)
        {
            return repositoriocategoria.Actualizar(t);
        }
        public bool Eliminar(Categoria t)
        {
            return repositoriocategoria.Eliminar(t);
        }

        public List<Categoria> Listar()
        {
            return repositoriocategoria.Listar();
        }

        public Categoria ListarPorId(int? Id)
        {
            return repositoriocategoria.ListarPorId(Id);
        }
    }
}