using System.Collections.Generic;

namespace Roffus.Repository
{
    public interface IRepositorioCRUDE<T>
    {
        bool Insertar(T t);
        bool Actualizar(T t);
        bool Eliminar(T t);
        List<T> Listar();
        T ListarPorId(int? Id);


    }
}