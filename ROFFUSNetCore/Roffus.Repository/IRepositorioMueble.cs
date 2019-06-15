using Roffus.Domain;
using System.Collections.Generic;

namespace Roffus.Repository
{
    public interface IRepositorioMueble : IRepositorioCRUDE<Mueble>
    {
      List<Mueble> ListBySubCategory(string subcat);
    }
}
