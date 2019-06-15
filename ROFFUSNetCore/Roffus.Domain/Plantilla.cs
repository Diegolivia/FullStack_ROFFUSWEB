using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Roffus.Domain
{
    public class Plantilla
    {
        [Key]
        public int CodPlantilla { get; set; }
        public String Diseño { get; set; }
        public double Alto { get; set; }
        public double Ancho { get; set; }
        public double Largo { get; set; }

        //////////////////////////////////////////////
        public List<Paquete> Paquetes {get;set;}

    }
}