using System;
using System.ComponentModel.DataAnnotations;
namespace Roffus.Domain
{
    public class Paquete
    {
        [Key]
        public int CodPaquete { get; set; }

        public String nombrePaquete{get;set;}


        /////////////////////////////////////////////////////////////////////
        public int CodPlantilla {get; set;}
        public Plantilla Plantilla { get; set; }

        public int CodUsuario {get; set; }
        public Usuario Usuario { get; set; }

        public int CodLista{get;set;}
        public ListaMuebles ListaMuebles { get; set; }


    }
}