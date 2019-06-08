using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

    }
}