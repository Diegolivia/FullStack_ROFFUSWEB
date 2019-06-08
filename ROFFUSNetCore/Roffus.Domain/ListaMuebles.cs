using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        public Mueble CodMueble { get; set; }


    }
}