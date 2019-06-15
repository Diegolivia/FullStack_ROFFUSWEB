using System.Collections.Generic;
using System.Linq;
using Roffus.Domain;
using Roffus.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Roffus.Repository.Implementations
{
 public class RepositorioUsuario :IRepositorioUsuario
    {
        private ApplicationDbContext Context;
        public RepositorioUsuario(ApplicationDbContext Context)
        {
            this.Context=Context;
        }       

        public bool Eliminar(Usuario entity)
        {
            Context.Usuarios.Remove(entity);
            Context.SaveChanges();
                        return true;
        }

        public List<Usuario> Listar()
        {
            return Context.Usuarios.ToList();
        }
        public Usuario ListarPorId(int? id)
        {
            var Usuario = Context.Usuarios.FirstOrDefault(x => x.CodUsuario == id);
            return Usuario;

        }

        public bool Insertar(Usuario entity)
        {
            Context.Usuarios.Add(entity);
            Context.SaveChanges();
            return true;
        }

        public bool Actualizar(Usuario entity)
        {
            Context.Entry(entity).State=EntityState.Modified;
            Context.SaveChanges();
            return true;
        }

  }
}