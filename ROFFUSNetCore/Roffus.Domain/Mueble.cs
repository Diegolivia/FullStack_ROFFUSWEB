using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Roffus.Domain
{
    public class Mueble
    {
                [Key]
        public int CodMueble { get; set; }
        public String NombreMueble { get; set; }
        public double Alto { get; set; }
        public double Ancho { get; set; }
        public double Largo { get; set; }
        public TiendaVirtual CodTienda { get; set; }
        public SubCategoria CodSubCategoria { get; set; }
        public String Descripcion { get; set; }
        public String Imagen { get; set; }
        public String Icono { get; set; }

    }
}