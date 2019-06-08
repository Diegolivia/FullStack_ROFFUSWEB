using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Service;
using Microsoft.AspNetCore.Mvc;


namespace Roffus.Api.Controllers
{

    [Route("api/categoria")]
    [ApiController]

    public class CategoriaController : ControllerBase
    {
  
        private IServicioCategoria categoriaServicio;

        public CategoriaController(IServicioCategoria categoriaServicio)
        {
            this.categoriaServicio = categoriaServicio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return categoriaServicio.Listar();
        }

        [HttpGet("{id}", Name="GetCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var autor = categoriaServicio.ListarPorId(id);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] Categoria categoria)
        {
            categoriaServicio.Insertar(categoria);
            return new CreatedAtRouteResult("GetCategoria",new{id = categoria.CodCategoria},categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==categoria.CodCategoria){
                categoriaServicio.Actualizar(categoria);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetCategoria",id=categoria.CodCategoria,categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id,[FromBody] Categoria categoria)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==categoria.CodCategoria){
                categoriaServicio.Eliminar(categoria);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetCategoria",id=categoria.CodCategoria,categoria);

        }

    }
}