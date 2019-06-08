using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Service;
using Microsoft.AspNetCore.Mvc;


namespace Roffus.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PaqueteController : ControllerBase
    {
        private IServicioPaquete servicioPaquete;

        public PaqueteController(IServicioPaquete servicioPaquete)
        {
            this.servicioPaquete = servicioPaquete;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Paquete>> Get()
        {
            return servicioPaquete.Listar();
        }

        [HttpGet("{id}", Name="GetPaquete")]
        public ActionResult<Paquete> Get(int id)
        {
            var autor = servicioPaquete.ListarPorId(id);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] Paquete paquete)
        {
            servicioPaquete.Insertar(paquete);
            return new CreatedAtRouteResult("GetPaquete",new{id = paquete.CodPaquete},paquete);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Paquete paquete)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==paquete.CodPaquete){
                servicioPaquete.Actualizar(paquete);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetPaquete",id=paquete.CodPaquete,paquete);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id,[FromBody] Paquete paquete)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==paquete.CodPaquete){
                servicioPaquete.Eliminar(paquete);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetPaquete",id=paquete.CodPaquete,paquete);

        }

    }
}