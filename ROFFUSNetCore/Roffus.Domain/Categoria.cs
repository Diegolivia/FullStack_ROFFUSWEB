using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Roffus.Domain
{
    public class Categoria
    {
        [Key]
        public int CodCategoria { get; set; }
        public String NombreCategoria { get; set; }

    }
}