using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Usuario
    {
        public int CodUsuario { get; set; }
        public String NombreUsuario { get; set; }
        public String Correo { get; set; }
        public String Contraseña { get; set; }
        public DateTime FNacimiento { get; set; }
        public String Foto { get; set; }

    }
}