using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Service;
using Microsoft.AspNetCore.Mvc;


namespace Roffus.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class TiendaVirtualController : ControllerBase
    {
        private IServicioTiendaVirtual servicioTiendaVirtual;

        public TiendaVirtualController(IServicioTiendaVirtual servicioTiendaVirtual)
        {
            this.servicioTiendaVirtual = servicioTiendaVirtual;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TiendaVirtual>> Get()
        {
            return servicioTiendaVirtual.Listar();
        }

        [HttpGet("{id}", Name="GetTiendaVirtual")]
        public ActionResult<TiendaVirtual> Get(int id)
        {
            var autor = servicioTiendaVirtual.ListarPorId(id);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] TiendaVirtual tiendaVirtual)
        {
            servicioTiendaVirtual.Insertar(tiendaVirtual);
            return new CreatedAtRouteResult("GetTiendaVirtual",new{id = tiendaVirtual.CodTienda},tiendaVirtual);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TiendaVirtual tiendaVirtual)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==tiendaVirtual.CodTienda){
                servicioTiendaVirtual.Actualizar(tiendaVirtual);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetTiendaVirtual",id=tiendaVirtual.CodTienda,tiendaVirtual);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id,[FromBody] TiendaVirtual tiendaVirtual)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==tiendaVirtual.CodTienda){
                servicioTiendaVirtual.Eliminar(tiendaVirtual);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetTiendaVirtual",id=tiendaVirtual.CodTienda,tiendaVirtual);

        }

    }
}