using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Paquete
    {
        public int CodPaquete { get; set; }
        public Plantilla CodPlantilla { get; set; }
        public Usuario CodUsuario { get; set; }
        public ListaMuebles NombreLista { get; set; }


    }
}