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
    public class RepositorioTiendaVirtual : IRepositorioTiendaVirtual
    {
        public bool Insertar(TiendaVirtual t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("INSERT INTO TiendaVirtual VALUES(@NombreTienda, @Link)", conexion);
                    query.Parameters.AddWithValue("@NombreTienda", t.NombreTienda);
                    query.Parameters.AddWithValue("@Link", t.Link);

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

        public bool Actualizar(TiendaVirtual t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE TiendaVirtual SET NombreTienda=@NombreTienda, Link=@Link WHERE CodTienda=@CodTienda", conexion);
                    query.Parameters.AddWithValue("@CodTienda", t.CodTienda);
                    query.Parameters.AddWithValue("@NombreTienda", t.NombreTienda);
                    query.Parameters.AddWithValue("@Link", t.Link);

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
        public bool Eliminar(TiendaVirtual t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("DELETE TiendaVirtual WHERE CodTienda=@CodTienda", conexion);
                    query.Parameters.AddWithValue("@CodTienda", t.CodTienda);

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

        public List<TiendaVirtual> Listar()
        {
            var tiendavirtuales = new List<TiendaVirtual>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT t.CodTienda,t.NombreTienda,t.Link FROM TiendaVirtual t", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tiendavirtual = new TiendaVirtual();

                            tiendavirtual.CodTienda = Convert.ToInt32(dr["CodTienda"]);
                            tiendavirtual.NombreTienda = dr["NombreTienda"].ToString();
                            tiendavirtual.Link = dr["Link"].ToString();

                            tiendavirtuales.Add(tiendavirtual);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tiendavirtuales;
        }

        public TiendaVirtual ListarPorId(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
