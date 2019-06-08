using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Service;
using Microsoft.AspNetCore.Mvc;


namespace Roffus.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ListaMueblesController : ControllerBase
    {
        private IServicioListaMuebles servicioListaMuebles;

        public ListaMueblesController(IServicioListaMuebles servicioListaMuebles)
        {
            this.servicioListaMuebles = servicioListaMuebles;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ListaMuebles>> Get()
        {
            return servicioListaMuebles.Listar();
        }

        [HttpGet("{id}", Name="GetListaMuebles")]
        public ActionResult<ListaMuebles> Get(int id)
        {
            var autor = servicioListaMuebles.ListarPorId(id);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] ListaMuebles listaMuebles)
        {
            servicioListaMuebles.Insertar(listaMuebles);
            return new CreatedAtRouteResult("GetListaMuebles",new{id = listaMuebles.CodLista},listaMuebles);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ListaMuebles listaMuebles)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==listaMuebles.CodLista){
                servicioListaMuebles.Actualizar(listaMuebles);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetListaMuebles",id = listaMuebles.CodLista,listaMuebles);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id,[FromBody] ListaMuebles listaMuebles)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==listaMuebles.CodLista){
                servicioListaMuebles.Eliminar(listaMuebles);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetListaMuebles",id = listaMuebles.CodLista,listaMuebles);

        }


    }
}