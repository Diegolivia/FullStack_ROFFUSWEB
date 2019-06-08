using Roffus.Repository;
using Roffus.Repository.Implementations;
using System.Collections.Generic;
using Roffus.Domain;

namespace Roffus.Service.Implementations
{
    public class ServicioUsuario:IServicioUsuario
    {
      private IRepositorioUsuario usuarioRepositorio;

         public ServicioUsuario(IRepositorioUsuario usuarioRepositorio){
            this.usuarioRepositorio=usuarioRepositorio;
        }

        public bool Insertar(Usuario t){
            return usuarioRepositorio.Insertar(t);
        }
        public bool Actualizar(Usuario t){
            return usuarioRepositorio.Actualizar(t);
        }
        public bool Eliminar(Usuario t){
            return usuarioRepositorio.Eliminar(t);
        }
        public List<Usuario> Listar(){
            return usuarioRepositorio.Listar();
        }
        public Usuario ListarPorId(int? Id){
            return usuarioRepositorio.ListarPorId(Id);
        }

    }
}