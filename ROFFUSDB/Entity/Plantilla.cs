using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Plantilla
    {
        public int CodPlantilla { get; set; }
        public String Diseño { get; set; }
        public double Alto { get; set; }
        public double Ancho { get; set; }
        public double Largo { get; set; }

    }
}