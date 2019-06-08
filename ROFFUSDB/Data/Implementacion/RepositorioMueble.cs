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
    public class RepositorioMueble : IRepositorioMueble
    {
        public bool Insertar(Mueble t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("INSERT INTO Mueble VALUES(@NombreMueble,@Alto,@Ancho,@Largo,@CodCategoria,@CodTienda,@Descripcion,@Imagen,@Icono)", conexion);
                    query.Parameters.AddWithValue("@NombreMueble", t.NombreMueble);
                    query.Parameters.AddWithValue("@Alto", t.Alto);
                    query.Parameters.AddWithValue("@Ancho", t.Ancho);
                    query.Parameters.AddWithValue("@Largo", t.Largo);
                    query.Parameters.AddWithValue("@CodCategoria", t.CodCategoria.CodCategoria);
                    query.Parameters.AddWithValue("@CodTienda", t.CodTienda.CodTienda);
                    query.Parameters.AddWithValue("@Descripcion", t.Descripcion);
                    query.Parameters.AddWithValue("@Imagen", t.Imagen);
                    query.Parameters.AddWithValue("@Icono", t.Icono);

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

        public bool Actualizar(Mueble t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE Mueble SET NombreMueble=@NombreMueble,Alto=@Alto,Ancho=@Ancho,Largo=@Largo,CodCategoria=@CodCategoria,CodTienda=@CodTienda,Descripcion=@Descripcion,Imagen=@Imagen,Icono=@Icono WHERE CodMueble=@CodMueble", conexion);
                    query.Parameters.AddWithValue("@CodMueble", t.CodMueble);
                    query.Parameters.AddWithValue("@NombreMueble", t.NombreMueble);
                    query.Parameters.AddWithValue("@Alto", t.Alto);
                    query.Parameters.AddWithValue("@Ancho", t.Ancho);
                    query.Parameters.AddWithValue("@Largo", t.Largo);
                    query.Parameters.AddWithValue("@CodCategoria", t.CodCategoria);
                    query.Parameters.AddWithValue("@CodTienda", t.CodTienda);
                    query.Parameters.AddWithValue("@Descripcion", t.Descripcion);
                    query.Parameters.AddWithValue("@Imagen", t.Imagen);
                    query.Parameters.AddWithValue("@Icono", t.Icono);

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
        public bool Eliminar(Mueble t)
        {
            bool rpta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("DELETE Mueble WHERE CodMueble=@CodMueble", conexion);
                    query.Parameters.AddWithValue("@CodMueble", t.CodMueble);

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

        public List<Mueble> Listar()
        {
            var Muebles = new List<Mueble>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["roffusdb"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT t.CodMueble,t.NombreMueble,t.Alto,t.Ancho,t.Largo,t.CodCategoria,t.CodTienda,t.Descripcion,t.Imagen,t.Icono FROM Mueble t", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var Mueble = new Mueble();
                            var Categoria = new Categoria();
                            var TiendaVirtual = new TiendaVirtual();

                            Mueble.CodMueble = Convert.ToInt32(dr["CodMueble"]);
                            Mueble.NombreMueble = dr["NombreMueble"].ToString();
                            Mueble.Alto = Convert.ToInt32(dr["Alto"]);
                            Mueble.Ancho = Convert.ToInt32(dr["Ancho"]);
                            Mueble.Largo = Convert.ToInt32(dr["Largo"]);
                            Mueble.Descripcion = dr["Descripcion"].ToString();
                            Mueble.Imagen = dr["Imagen"].ToString();
                            Mueble.Icono = dr["Icono"].ToString();

                            Categoria.CodCategoria = Convert.ToInt32(dr["CodCategoria"]);
                            TiendaVirtual.CodTienda = Convert.ToInt32(dr["CodTienda"]);

                            Muebles.Add(Mueble);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Muebles;
        }

        public Mueble ListarPorId(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
