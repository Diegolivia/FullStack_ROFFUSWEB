using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Roffus.Domain
{
    public class TiendaVirtual
    {
                [Key]
        public int CodTienda { get; set; }
        public String NombreTienda { get; set; }
        public String Link { get; set; }

    }
}