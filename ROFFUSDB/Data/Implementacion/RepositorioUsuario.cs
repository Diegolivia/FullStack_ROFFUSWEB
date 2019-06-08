using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Configuration;
using System.Data.SqlClient;

namespace Data.Implementacion
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public bool Insertar(Usuario t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("INSERT INTO Usuario VALUES(@NombreUsuario,@Correo,@Contraseña,@FNacimiento,@Foto", conexion);
                    query.Parameters.AddWithValue("@NombreUsuario", t.NombreUsuario);
                    query.Parameters.AddWithValue("@Correo", t.Correo);
                    query.Parameters.AddWithValue("@Contraseña", t.Contraseña);
                    query.Parameters.AddWithValue("@FNacimiento", t.FNacimiento);
                    query.Parameters.AddWithValue("@Foto", t.Foto);


                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rpta;
        }

        public bool Actualizar(Usuario t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE Usuario SET NombreUsuario=@NombreUsuario, Correo=@Correo, Contraseña=@Contraseña,FNacimineto=@FNacimiento,Foto=@Foto WHERE CodUsuario=@CodUsuario", conexion);
                    query.Parameters.AddWithValue("@CodUsuario", t.CodUsuario);
                    query.Parameters.AddWithValue("@NombreUsuario", t.NombreUsuario);
                    query.Parameters.AddWithValue("@Correo", t.Correo);
                    query.Parameters.AddWithValue("@Contraseña", t.Contraseña);
                    query.Parameters.AddWithValue("@FNacimiento", t.FNacimiento);
                    query.Parameters.AddWithValue("@Foto", t.Foto);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rpta;
        }
        public bool Eliminar(Usuario t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("DELETE Usuario WHERE CodUsuario=@CodUsuario", conexion);
                    query.Parameters.AddWithValue("@CodUsuario", t.CodUsuario);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rpta;
        }

        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT t.CodUsuario,t.NombreUsuario,t.Correo,t.Contraseña,t.FNacimiento,t.Foto FROM Usuario t", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var usuario = new Usuario();

                            usuario.CodUsuario = Convert.ToInt32(dr["CodUsuario"]);
                            usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                            usuario.Correo = dr["Correo"].ToString();
                            usuario.Contraseña = dr["Contraseña"].ToString();
                            usuario.FNacimiento = Convert.ToDateTime(dr["FNacimiento"]);
                            usuario.Foto = dr["Foto"].ToString();

                            usuarios.Add(usuario);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuarios;
        }

        public Usuario ListarPorId(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}

