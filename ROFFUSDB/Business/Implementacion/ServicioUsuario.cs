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
    public class ServicioUsuario:IServicioUsuario
    {
        private IRepositorioUsuario repositoriousuario = new RepositorioUsuario();
        public bool Insertar(Usuario t)
        {
            return repositoriousuario.Insertar(t);
        }
        public bool Actualizar(Usuario t)
        {
            return repositoriousuario.Actualizar(t);
        }
        public bool Eliminar(Usuario t)
        {
            return repositoriousuario.Eliminar(t);
        }

        public List<Usuario> Listar()
        {
            return repositoriousuario.Listar();
        }

        public Usuario ListarPorId(int? Id)
        {
            return repositoriousuario.ListarPorId(Id);
        }
    }
}
