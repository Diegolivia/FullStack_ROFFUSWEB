using Roffus.Repository;
using System.Collections.Generic;

namespace Roffus.Service
{
    public interface IServicioCRUD<T>
    {
        bool Insertar(T t);
        bool Actualizar(T t);
        bool Eliminar(T t);
        List<T> Listar();
        T ListarPorId(int? Id);
    }
}