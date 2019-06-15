using System.Collections.Generic;
using Roffus.Domain;
using Roffus.Service;
using Microsoft.AspNetCore.Mvc;


namespace Roffus.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private IServicioUsuario servicioUsuario;

        public UsuarioController(IServicioUsuario servicioUsuario)
        {
            this.servicioUsuario = servicioUsuario;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return servicioUsuario.Listar();
        }

        [HttpGet("{id}", Name="GetUsuario")]
        public ActionResult<Usuario> Get(int id)
        {
            var autor = servicioUsuario.ListarPorId(id);
            if(autor== null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] Usuario usuario)
        {
            servicioUsuario.Insertar(usuario);
            return new CreatedAtRouteResult("GetUsuario",new{id = usuario.CodUsuario},usuario);
        }

    }
}