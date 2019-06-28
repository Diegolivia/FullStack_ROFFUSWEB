using Roffus.Repository;
using Roffus.Repository.Implementations;
using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Repository.Context;

namespace Roffus.Service.Implementations
{
    public class ServicioSubCategoria:IServicioSubCategoria
    {
        private IRepositorioSubCategoria SubCategoriaRepositorio;
        public ServicioSubCategoria(IRepositorioSubCategoria SubCategoriaRepositorio){
            this.SubCategoriaRepositorio=SubCategoriaRepositorio;
        }

        public bool Insertar(SubCategoria t){
            return SubCategoriaRepositorio.Insertar(t);
        }
        public bool Actualizar(SubCategoria t){
            return SubCategoriaRepositorio.Actualizar(t);
        }
        public bool Eliminar(SubCategoria t){
            return SubCategoriaRepositorio.Eliminar(t);
        }
        public List<SubCategoria> Listar(){
            return SubCategoriaRepositorio.Listar();
        }
        public SubCategoria ListarPorId(int? Id){
            return SubCategoriaRepositorio.ListarPorId(Id);
        }

    }
}