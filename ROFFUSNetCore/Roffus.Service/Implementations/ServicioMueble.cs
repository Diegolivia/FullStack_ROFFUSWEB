using Roffus.Repository;
using Roffus.Repository.Implementations;
using System.Collections.Generic;
using Roffus.Domain;

namespace Roffus.Service.Implementations
{
    public class ServicioMueble:IServicioMueble
    {
        private IRepositorioMueble muebleRepositorio;

        public ServicioMueble(IRepositorioMueble muebleRepositorio){
            this.muebleRepositorio=muebleRepositorio;
        }

        public bool Insertar(Mueble t){
            return muebleRepositorio.Insertar(t);
        }
        public bool Actualizar(Mueble t){
            return muebleRepositorio.Actualizar(t);
        }
        public bool Eliminar(Mueble t){
            return muebleRepositorio.Eliminar(t);
        }
        public List<Mueble> Listar(){
            return muebleRepositorio.Listar();
        }
        public Mueble ListarPorId(int? Id){
            return muebleRepositorio.ListarPorId(Id);
        }

    }
}