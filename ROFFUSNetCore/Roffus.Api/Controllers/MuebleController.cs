using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Service;
using Microsoft.AspNetCore.Mvc;


namespace Roffus.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class MuebleController : ControllerBase
    {
        private IServicioMueble servicioMueble;

        public MuebleController(IServicioMueble servicioMueble)
        {
            this.servicioMueble = servicioMueble;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Mueble>> Get()
        {
            return servicioMueble.Listar();
        }

        //Por ID, no utilizado
        //[HttpGet("{id}", Name="GetMueble")]
       /* public ActionResult<Mueble> Get(int id)
        {
            var autor = servicioMueble.ListarPorId(id);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }*/

        //Por Categoria, usable
        [HttpGet("{cat}", Name="GetMueble")]
        public ActionResult<IEnumerable<Mueble>> Get(string cat)
        {
            var autor = servicioMueble.ListByCategory(cat);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }


        [HttpPost]
        public ActionResult Post ([FromBody] Mueble mueble)
        {
            servicioMueble.Insertar(mueble);
            return new CreatedAtRouteResult("GetMueble",new{id = mueble.CodMueble},mueble);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Mueble mueble)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==mueble.CodMueble){
                servicioMueble.Actualizar(mueble);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetMueble",id = mueble.CodMueble,mueble);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id,[FromBody] Mueble mueble)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==mueble.CodMueble){
                servicioMueble.Eliminar(mueble);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetMueble",id=mueble.CodMueble,mueble);

        }

        
        

    }
}