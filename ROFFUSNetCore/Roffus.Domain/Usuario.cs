using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Roffus.Domain
{
    public class Usuario
    {
        [Key]
        public int CodUsuario { get; set; }
        public String NombreUsuario { get; set; }
        public String Correo { get; set; }
        public String Contraseña { get; set; }
        public DateTime FNacimiento { get; set; }
        public String Foto { get; set; }

        ////////////////////////////////////////////////////////////

          public List<Paquete> Paquetes {get;set;}

    }
}