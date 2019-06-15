using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Service;
using Microsoft.AspNetCore.Mvc;


namespace Roffus.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PlantillaController : ControllerBase
    {
        private IServicioPlantilla servicioPlantilla;

        public PlantillaController(IServicioPlantilla servicioPlantilla)
        {
            this.servicioPlantilla = servicioPlantilla;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Plantilla>> Get()
        {
            return servicioPlantilla.Listar();
        }

        [HttpGet("{id}", Name="GetPlantilla")]
        public ActionResult<Plantilla> Get(int id)
        {
            var autor = servicioPlantilla.ListarPorId(id);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] Plantilla plantilla)
        {
            servicioPlantilla.Insertar(plantilla);
            return new CreatedAtRouteResult("GetPlantilla",new{id = plantilla.CodPlantilla},plantilla);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Plantilla plantilla)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==plantilla.CodPlantilla){
                servicioPlantilla.Actualizar(plantilla);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetPlantilla",id=plantilla.CodPlantilla,plantilla);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id,[FromBody] Plantilla plantilla)
        {
            if(!ModelState.IsValid){
                 return BadRequest(ModelState);
            }

            if(id==plantilla.CodPlantilla){
                servicioPlantilla.Eliminar(plantilla);  
            }
            else{
               return NotFound();
            }
             return new  CreatedAtRouteResult("GetPlantilla",id=plantilla.CodPlantilla,plantilla);

        }

    }
}