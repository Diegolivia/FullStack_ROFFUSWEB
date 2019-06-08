using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class ListaMuebles
    {
        public int CodLista { get; set; }
        public String NombreLista { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public double Rotacion { get; set; }
        public Mueble CodMueble { get; set; }


    }
}