using Roffus.Repository;
using Roffus.Repository.Implementations;
using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Repository.Context;

namespace Roffus.Service.Implementations
{
    public class ServicioSubcategoria:IServicioSubcategoria
    {
         private IRepositorioSubCategoria subcategoriaRepositorio;

         public ServicioSubcategoria(IRepositorioSubCategoria subcategoriaRepositorio){
             this.subcategoriaRepositorio=subcategoriaRepositorio;
         }

         public bool Insertar(Subcategoria t){
            return subcategoriaRepositorio.Insertar(t);
        }
        public bool Actualizar(Subcategoria t){
            return subcategoriaRepositorio.Actualizar(t);
        }
        public bool Eliminar(Subcategoria t){
            return subcategoriaRepositorio.Eliminar(t);
        }
        public List<Subcategoria> Listar(){
            return subcategoriaRepositorio.Listar();
        }
        public Subcategoria ListarPorId(int? Id){
            return subcategoriaRepositorio.ListarPorId(Id);
        }

        public List<Subcategoria> ListByCategory(string cat){
            return subcategoriaRepositorio.ListByCategory(cat);
        }

    }
}