using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepositorioCRUD<T>
    {
        bool Insertar(T t);
        bool Actualizar(T t);
        bool Eliminar(T t);
        List<T> Listar();
        T ListarPorId(int? Id);
    }
}

