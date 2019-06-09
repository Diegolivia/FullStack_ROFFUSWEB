using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Service;
using Microsoft.AspNetCore.Mvc;

namespace Roffus.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private IServicioSubcategoria subcategoriaServicio;

        public SubcategoriaController(IServicioSubcategoria subcategoriaServicio)
        {
            this.subcategoriaServicio = subcategoriaServicio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Subcategoria>> Get()
        {
            return subcategoriaServicio.Listar();
        }

        [HttpGet("{id}", Name="GetSubcategoria")]
        public ActionResult<Subcategoria> Get(int id)
        {
            var autor = subcategoriaServicio.ListarPorId(id);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpGet("{cat}", Name="GetListByCategory")]
        public ActionResult<IEnumerable<Subcategoria>> Get(string cat)
        {
            var autor = subcategoriaServicio.ListByCategory(cat);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }


        [HttpPost]
        public ActionResult Post ([FromBody] Subcategoria subcategoria)
        {
            subcategoriaServicio.Insertar(subcategoria);
            return new CreatedAtRouteResult("GetSubcategoria",new{id = subcategoria.codSubCategoria},subcategoria);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Subcategoria subcategoria)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==subcategoria.codSubCategoria){
                subcategoriaServicio.Actualizar(subcategoria);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetSubcategoria",id=subcategoria.codSubCategoria,subcategoria);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id,[FromBody] Subcategoria subcategoria)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==subcategoria.codSubCategoria){
                subcategoriaServicio.Eliminar(subcategoria);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetSubcategoria",id=subcategoria.codSubCategoria,subcategoria);

        }

    }
}