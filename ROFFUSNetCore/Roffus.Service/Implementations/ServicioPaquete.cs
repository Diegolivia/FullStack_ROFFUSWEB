using Roffus.Repository;
using Roffus.Repository.Implementations;
using System.Collections.Generic;
using Roffus.Domain;

namespace Roffus.Service.Implementations
{
    public class ServicioPaquete:IServicioPaquete
    {
    private IRepositorioPaquete paqueteRepositorio;

        public ServicioPaquete(IRepositorioPaquete paqueteRepositorio){
             this.paqueteRepositorio=paqueteRepositorio;
        }  

        public bool Insertar(Paquete t){
            return paqueteRepositorio.Insertar(t);
        }
        public bool Actualizar(Paquete t){
            return paqueteRepositorio.Actualizar(t);
        }
        public bool Eliminar(Paquete t){
            return paqueteRepositorio.Eliminar(t);
        }
        public List<Paquete> Listar(){
            return paqueteRepositorio.Listar();
        }
        public Paquete ListarPorId(int? Id){
            return paqueteRepositorio.ListarPorId(Id);
        }
        public List<Paquete> ListByUsuario(string user){
            return paqueteRepositorio.ListByUsuario(user);
        }

    }
}