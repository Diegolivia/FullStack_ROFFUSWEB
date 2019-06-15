using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Roffus.Domain
{
    public class ListaMuebles
    {
        [Key]
        public int CodLista { get; set; }
        public String NombreLista { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public double Rotacion { get; set; }
        
        ///////////////////////////////////////////////////////

        public int CodMueble {get; set;}
        public Mueble Mueble { get; set; }

        public List<Paquete> Paquetes {get;set;}


    }
}