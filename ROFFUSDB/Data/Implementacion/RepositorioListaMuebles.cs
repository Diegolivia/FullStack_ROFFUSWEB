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
    public class RepositorioListaMuebles : IRepositorioListaMuebles
    {
        public bool Insertar(ListaMuebles t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("INSERT INTO ListaMuebles VALUES(@NombreLista,@CodMueble,@CoordX,@CoordY,@Rotacion)", conexion);
                    query.Parameters.AddWithValue("@NombreLista", t.NombreLista);
                    query.Parameters.AddWithValue("@CodMueble", t.CodMueble.CodMueble);
                    query.Parameters.AddWithValue("@CoordX", t.CoordX);
                    query.Parameters.AddWithValue("@CoordY", t.CoordY);
                    query.Parameters.AddWithValue("@Rotacion", t.Rotacion);

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

        public bool Actualizar(ListaMuebles t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE ListaMuebles SET NombreLista=@NombreLista,CodMueble=@CodMueble,CoordX=@CoordX,CoordY=@CoordY,Rotacion=@Rotacion WHERE CodLista=@CodLista", conexion);
                    query.Parameters.AddWithValue("@CodLista", t.CodLista);
                    query.Parameters.AddWithValue("@NombreLista", t.NombreLista);
                    query.Parameters.AddWithValue("@CodMueble", t.CodMueble.CodMueble);
                    query.Parameters.AddWithValue("@CoordX", t.CoordX);
                    query.Parameters.AddWithValue("@CoordY", t.CoordY);
                    query.Parameters.AddWithValue("@Rotacion", t.Rotacion);

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
        public bool Eliminar(ListaMuebles t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("DELETE ListaMuebles WHERE CodLista=@CodLista", conexion);
                    query.Parameters.AddWithValue("@CodLista", t.CodLista);

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

        public List<ListaMuebles> Listar()
        {
            var ListaMuebles = new List<ListaMuebles>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT t.CodLista,t.NombreLista,t.CodMueble,t.CoordX,t.CoordY,t.Rotacion FROM ListaMuebles t", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ListaMueble = new ListaMuebles();
                            var Mueble = new Mueble();

                            ListaMueble.CodLista = Convert.ToInt32(dr["CodLista"]);
                            ListaMueble.NombreLista = dr["NombreLista"].ToString();
                            ListaMueble.CoordX = Convert.ToInt32(dr["CoordX"]);
                            ListaMueble.CoordY = Convert.ToInt32(dr["CoordY"]);
                            ListaMueble.Rotacion = Convert.ToInt32(dr["Rotacion"]);

                            Mueble.CodMueble = Convert.ToInt32(dr["CodMueble"]);


                            ListaMuebles.Add(ListaMueble);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ListaMuebles;
        }

        public ListaMuebles ListarPorId(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
