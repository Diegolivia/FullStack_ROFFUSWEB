using Roffus.Domain;
using System.Collections.Generic;

namespace Roffus.Service
{
    public interface IServicioMueble:IServicioCRUD<Mueble>
    {
         List<Mueble> ListBySubCategory(string subcat);
    }
}