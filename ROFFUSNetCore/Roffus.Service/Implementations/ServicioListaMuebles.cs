using Roffus.Repository;
using Roffus.Repository.Implementations;
using System.Collections.Generic;
using Roffus.Domain;

namespace Roffus.Service.Implementations
{
    public class ServicioListaMuebles:IServicioListaMuebles
    {
       private IRepositorioListaMuebles listaMueblesRepositorio;

         public ServicioListaMuebles(IRepositorioListaMuebles listaMueblesRepositorio){
            this.listaMueblesRepositorio=listaMueblesRepositorio;
        }

        public bool Insertar(ListaMuebles t){
            return listaMueblesRepositorio.Insertar(t);
        }
        public bool Actualizar(ListaMuebles t){
            return listaMueblesRepositorio.Actualizar(t);
        }
        public bool Eliminar(ListaMuebles t){
            return listaMueblesRepositorio.Eliminar(t);
        }
        public List<ListaMuebles> Listar(){
            return listaMueblesRepositorio.Listar();
        }
        public ListaMuebles ListarPorId(int? Id){
            return listaMueblesRepositorio.ListarPorId(Id);
        }

    }
}