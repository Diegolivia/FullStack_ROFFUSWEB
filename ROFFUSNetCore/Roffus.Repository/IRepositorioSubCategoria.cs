using Roffus.Domain;
using System.Collections.Generic;

namespace Roffus.Repository
{
    public interface IRepositorioSubCategoria:IRepositorioCRUDE<Subcategoria>
    {
           List<Subcategoria> ListByCategory(string cat);
    }
}