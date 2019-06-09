using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Roffus.Domain
{
    public class Subcategoria
    {
        [Key]
        public int codSubCategoria {get; set; }

        public String nombreSubCategoria {get;set; }

        public Categoria codigoCategoria {get; set; }
    }
}