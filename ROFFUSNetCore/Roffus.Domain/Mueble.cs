using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
    
      
        public String Descripcion { get; set; }
        public String Imagen { get; set; }
        public String Icono { get; set; }

////////////////////////////////////////////////////////////////////

        public int codSubCategoria{get;set;}
        public Subcategoria Subcategoria { get; set; }

        public int CodTienda {get;set;}
        public TiendaVirtual TiendaVirtual { get; set; }

        public List<ListaMuebles> ListaMuebles {get;set;}

    }
}