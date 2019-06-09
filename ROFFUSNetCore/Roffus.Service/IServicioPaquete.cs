using Roffus.Domain;

namespace Roffus.Service
{
    public interface IServicioPaquete:IServicioCRUD<Paquete>
    {
         List<Paquete> ListByUsuario(string user);
         List<Paquete> ListByListaMuebles(string listmuebles);
    }
}