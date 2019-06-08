using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

    }
}