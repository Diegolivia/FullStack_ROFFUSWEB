using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementacion;
using Entity;

namespace ROFFUSDB.Controllers
{
    public class UsuarioController : Controller
    {
        private IServicioUsuario servicioUsuario = new ServicioUsuario();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(servicioUsuario.Listar());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            bool rptainsert = servicioUsuario.Insertar(usuario);

            if (rptainsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int CUsuario)
        {
            var usuario = servicioUsuario.Listar()
                        .Where(t => t.CodUsuario == CUsuario)
                        .FirstOrDefault();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            var r = usuario.CodUsuario > 0 ?
                  servicioUsuario.Actualizar(usuario) :
                  servicioUsuario.Insertar(usuario);

            if (!r)
            {
                ViewBag.Message = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CUsuario)
        {
            var usuario = servicioUsuario.Listar()
                             .Where(t => t.CodUsuario == CUsuario)
                             .FirstOrDefault();

            servicioUsuario.Eliminar(usuario);

            return RedirectToAction("Index");
        }
    }
}