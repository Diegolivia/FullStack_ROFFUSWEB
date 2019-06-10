using Roffus.Domain;
using System.Collections.Generic;

namespace Roffus.Service
{
    public interface IServicioPaquete:IServicioCRUD<Paquete>
    {
         List<Paquete> ListByUsuario(string user);
    }
}