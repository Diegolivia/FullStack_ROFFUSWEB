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
    public class RepositorioPlantilla : IRepositorioPlantilla
    {
        public bool Insertar(Plantilla t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("INSERT INTO Plantilla VALUES(@Ancho, @Largo, @Alto,@Diseño)", conexion);
                    query.Parameters.AddWithValue("@Diseño", t.Diseño);
                    query.Parameters.AddWithValue("@Ancho", t.Ancho);
                    query.Parameters.AddWithValue("@Largo", t.Largo);
                    query.Parameters.AddWithValue("@Alto", t.Alto);

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

        public bool Actualizar(Plantilla t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE Plantilla SET  Ancho=@Ancho, Largo=@Largo, Alto=@Alto,Diseño=@Diseño WHERE CodPlantilla=@CodPlantilla", conexion);
                    query.Parameters.AddWithValue("@CodPlantilla", t.CodPlantilla);
                    query.Parameters.AddWithValue("@Diseño", t.Diseño);
                    query.Parameters.AddWithValue("@Ancho", t.Ancho);
                    query.Parameters.AddWithValue("@Largo", t.Largo);
                    query.Parameters.AddWithValue("@Alto", t.Alto);

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
        public bool Eliminar(Plantilla t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("DELETE Plantilla WHERE CodPlantilla=@CodPlantilla", conexion);
                    query.Parameters.AddWithValue("@CodPlantilla", t.CodPlantilla);

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

        public List<Plantilla> Listar()
        {
            var plantillas = new List<Plantilla>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT t.CodPlantilla,t.Diseño,t.Ancho, t.Largo, t.Alto FROM Plantilla t", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var plantilla = new Plantilla();

                            plantilla.CodPlantilla = Convert.ToInt32(dr["CodPlantilla"]);
                            plantilla.Diseño = dr["Diseño"].ToString();
                            plantilla.Ancho = Convert.ToDouble(dr["Ancho"]);
                            plantilla.Largo = Convert.ToDouble(dr["Largo"]);
                            plantilla.Alto = Convert.ToDouble(dr["Alto"]);

                            plantillas.Add(plantilla);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return plantillas;
        }

        public Plantilla ListarPorId(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
