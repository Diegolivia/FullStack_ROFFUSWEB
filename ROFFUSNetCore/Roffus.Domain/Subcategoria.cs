using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Roffus.Domain
{
    public class Subcategoria
    {
        [Key]
        public int codSubCategoria {get; set; }

        public String nombreSubCategoria {get;set; }

      

        //////////////////////////////////////////////////////////

          public int CodCategoria {get; set; }
          public Categoria Categoria{get;set;}

          public List<Mueble> Muebles {get; set;}

    }
}