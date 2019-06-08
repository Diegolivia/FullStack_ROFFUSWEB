using Roffus.Repository;
using Roffus.Repository.Implementations;
using System.Collections.Generic;
using Roffus.Domain;

namespace Roffus.Service.Implementations
{
    public class ServicioPlantilla:IServicioPlantilla
    {
      private IRepositorioPlantilla plantillaRepositorio;

        public ServicioPlantilla(IRepositorioPlantilla plantillaRepositorio){
            this.plantillaRepositorio=plantillaRepositorio;
        }

        public bool Insertar(Plantilla t){
            return plantillaRepositorio.Insertar(t);
        }
        public bool Actualizar(Plantilla t){
            return plantillaRepositorio.Actualizar(t);
        }
        public bool Eliminar(Plantilla t){
            return plantillaRepositorio.Eliminar(t);
        }
        public List<Plantilla> Listar(){
            return plantillaRepositorio.Listar();
        }
        public Plantilla ListarPorId(int? Id){
            return plantillaRepositorio.ListarPorId(Id);
        }

    }
}