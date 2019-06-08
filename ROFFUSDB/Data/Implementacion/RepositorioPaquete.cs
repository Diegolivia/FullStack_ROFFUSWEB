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
    public class RepositorioPaquete : IRepositorioPaquete
    {
        public bool Insertar(Paquete t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("INSERT INTO Paquete VALUES(@CodPaquete,@CodPlantilla,@CodUsuario,@NomLista)", conexion);
                    query.Parameters.AddWithValue("@CodPaquete", t.CodPaquete);
                    query.Parameters.AddWithValue("@CodPlantilla", t.CodPlantilla);
                    query.Parameters.AddWithValue("@CodUsuario", t.CodUsuario);
                    query.Parameters.AddWithValue("@NomLista", t.NombreLista);
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

        public bool Actualizar(Paquete t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE Paquete SET CodPlantilla=@CodPlantilla, CodUsuario=@CodUsuario " +
                        "NomLista=@NombreLista WHERE CodPaquete=@CodPaquete", conexion);
                    query.Parameters.AddWithValue("@CodPaquete", t.CodPaquete);
                    query.Parameters.AddWithValue("@codPlantilla", t.CodPlantilla);
                    query.Parameters.AddWithValue("@codUsuario", t.CodUsuario);
                    query.Parameters.AddWithValue("@NombreLista", t.NombreLista);

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
        public bool Eliminar(Paquete t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("DELETE Paquete WHERE CodPaquete=@CodPaquete", conexion);
                    query.Parameters.AddWithValue("@CodPaquete", t.CodPaquete);

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

        public List<Paquete> Listar()
        {
            var Paquetes = new List<Paquete>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT t.CodPaquete,t.CodPlantilla,t.CodUsuario,t.NombreLista FROM Paquete t", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var Paquete = new Paquete();
                            var Plantilla = new Plantilla();
                            var Usuario = new Usuario();
                            var ListaMueble = new ListaMuebles();

                            Paquete.CodPaquete = Convert.ToInt32(dr["CodPaquete"]);
                            Plantilla.CodPlantilla = Convert.ToInt32(dr["CodPlantilla"]);
                            Usuario.CodUsuario = Convert.ToInt32(dr["CodUsuario"]);
                            ListaMueble.NombreLista = dr["NombreLista"].ToString();

                            Paquetes.Add(Paquete);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Paquetes;
        }

        public Paquete ListarPorId(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
