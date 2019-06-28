using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Roffus.Domain
{
    public class SubCategoria
    {
        [Key]
        public int CodSubCategoria { get; set; }
        public String NombreSubCategoria { get; set; }
        public int CodCategoria{get;set;}

    }
}