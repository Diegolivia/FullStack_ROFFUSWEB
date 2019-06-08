using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Mueble
    {
        public int CodMueble { get; set; }
        public String NombreMueble { get; set; }
        public double Alto { get; set; }
        public double Ancho { get; set; }
        public double Largo { get; set; }
        public TiendaVirtual CodTienda { get; set; }
        public Categoria CodCategoria { get; set; }
        public String Descripcion { get; set; }
        public String Imagen { get; set; }
        public String Icono { get; set; }

    }
}