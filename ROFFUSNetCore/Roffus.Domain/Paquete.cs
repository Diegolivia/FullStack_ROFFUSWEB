using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Roffus.Domain
{
    public class Paquete
    {
                [Key]
        public int CodPaquete { get; set; }

        public String nombrePaquete{get;set;}
        public Plantilla CodPlantilla { get; set; }
        public Usuario CodUsuario { get; set; }
        public ListaMuebles NombreLista { get; set; }


    }
}