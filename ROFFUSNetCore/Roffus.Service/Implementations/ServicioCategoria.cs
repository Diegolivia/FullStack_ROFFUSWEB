using Roffus.Repository;
using Roffus.Repository.Implementations;
using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Repository.Context;

namespace Roffus.Service.Implementations
{
    public class ServicioCategoria:IServicioCategoria
    {
        private IRepositorioCategoria categoriaRepositorio;
        public ServicioCategoria(IRepositorioCategoria categoriaRepositorio){
            this.categoriaRepositorio=categoriaRepositorio;
        }

        public bool Insertar(Categoria t){
            return categoriaRepositorio.Insertar(t);
        }
        public bool Actualizar(Categoria t){
            return categoriaRepositorio.Actualizar(t);
        }
        public bool Eliminar(Categoria t){
            return categoriaRepositorio.Eliminar(t);
        }
        public List<Categoria> Listar(){
            return categoriaRepositorio.Listar();
        }
        public Categoria ListarPorId(int? Id){
            return categoriaRepositorio.ListarPorId(Id);
        }

    }
}