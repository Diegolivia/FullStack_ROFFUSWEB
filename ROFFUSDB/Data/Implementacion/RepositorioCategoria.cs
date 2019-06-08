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
    public class RepositorioCategoria : IRepositorioCategoria
    {
        public bool Insertar(Categoria t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("INSERT INTO Categoria VALUES(@NombreCategoria)", conexion);
                    query.Parameters.AddWithValue("@NombreCategoria", t.NombreCategoria);

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

        public bool Actualizar(Categoria t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE Categoria SET NombreCategoria=@NombreCategoria WHERE CodCategoria=@CodCategoria", conexion);
                    query.Parameters.AddWithValue("@CodCategoria", t.CodCategoria);
                    query.Parameters.AddWithValue("@NombreCategoria", t.NombreCategoria);

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
        public bool Eliminar(Categoria t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("DELETE Categoria WHERE CodCategoria=@CodCategoria", conexion);
                    query.Parameters.AddWithValue("@CodCategoria", t.CodCategoria);

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

        public List<Categoria> Listar()
        {
            var categorias = new List<Categoria>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT t.CodCategoria,t.NombreCategoria FROM Categoria t", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var categoria = new Categoria();

                            categoria.CodCategoria = Convert.ToInt32(dr["CodCategoria"]);
                            categoria.NombreCategoria = dr["NombreCategoria"].ToString();

                            categorias.Add(categoria);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return categorias;
        }

        public Categoria ListarPorId(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
