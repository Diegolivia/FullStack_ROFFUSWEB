using Roffus.Domain;
using System.Collections.Generic;

namespace Roffus.Repository
{
    public interface IRepositorioPaquete : IRepositorioCRUDE<Paquete>
    {
         List<Paquete> ListByUsuario(string user);

    }
}

