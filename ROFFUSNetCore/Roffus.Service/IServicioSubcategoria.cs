using Roffus.Domain;
using System.Collections.Generic;

namespace Roffus.Service
{
    public interface IServicioSubcategoria:IServicioCRUD<Subcategoria>
    {
          List<Subcategoria> ListByCategory(string cat);
    }
}