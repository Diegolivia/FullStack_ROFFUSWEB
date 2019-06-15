using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Roffus.Domain
{
    public class Categoria
    {
        [Key]
        public int CodCategoria { get; set; }
        public String NombreCategoria { get; set; }

        ////////////////////////////////////////////////////

        public List<Subcategoria> Subcategorias {get;set;}
    }
}