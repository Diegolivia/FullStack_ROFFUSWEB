using Roffus.Repository;
using Roffus.Repository.Implementations;
using System.Collections.Generic;
using Roffus.Domain;

namespace Roffus.Service.Implementations
{
    public class ServicioTiendaVirtual:IServicioTiendaVirtual
    {
     private IRepositorioTiendaVirtual tiendavirtualepositorio;

         public ServicioTiendaVirtual(IRepositorioTiendaVirtual tiendavirtualepositorio){
            this.tiendavirtualepositorio=tiendavirtualepositorio;
        }

        public bool Insertar(TiendaVirtual t){
            return tiendavirtualepositorio.Insertar(t);
        }
        public bool Actualizar(TiendaVirtual t){
            return tiendavirtualepositorio.Actualizar(t);
        }
        public bool Eliminar(TiendaVirtual t){
            return tiendavirtualepositorio.Eliminar(t);
        }
        public List<TiendaVirtual> Listar(){
            return tiendavirtualepositorio.Listar();
        }
        public TiendaVirtual ListarPorId(int? Id){
            return tiendavirtualepositorio.ListarPorId(Id);
        }

    }
}