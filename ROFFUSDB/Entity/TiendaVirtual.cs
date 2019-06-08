using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class TiendaVirtual
    {
        public int CodTienda { get; set; }
        public String NombreTienda { get; set; }
        public String Link { get; set; }

    }
}