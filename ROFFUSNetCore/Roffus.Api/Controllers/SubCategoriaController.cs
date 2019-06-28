using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Service;
using Microsoft.AspNetCore.Mvc;


namespace Roffus.Api.Controllers
{

    [Route("api/SubCategoria")]
    [ApiController]

    public class SubCategoriaController : ControllerBase
    {
  
        private IServicioSubCategoria SubCategoriaServicio;

        public SubCategoriaController(IServicioSubCategoria SubCategoriaServicio)
        {
            this.SubCategoriaServicio = SubCategoriaServicio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubCategoria>> Get()
        {
            return SubCategoriaServicio.Listar();
        }

        [HttpGet("{id}", Name="GetSubCategoria")]
        public ActionResult<SubCategoria> Get(int id)
        {
            var autor = SubCategoriaServicio.ListarPorId(id);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] SubCategoria SubCategoria)
        {
            SubCategoriaServicio.Insertar(SubCategoria);
            return new CreatedAtRouteResult("GetSubCategoria",new{id = SubCategoria.CodSubCategoria},SubCategoria);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SubCategoria SubCategoria)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==SubCategoria.CodSubCategoria){
                SubCategoriaServicio.Actualizar(SubCategoria);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetSubCategoria",id=SubCategoria.CodSubCategoria,SubCategoria);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id,[FromBody] SubCategoria SubCategoria)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==SubCategoria.CodSubCategoria){
                SubCategoriaServicio.Eliminar(SubCategoria);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetSubCategoria",id=SubCategoria.CodSubCategoria,SubCategoria);

        }

    }
}