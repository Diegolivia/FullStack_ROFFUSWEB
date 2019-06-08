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
    public class MuebleController : Controller
    {
        private IServicioMueble servicioMueble = new ServicioMueble();
        private IServicioTiendaVirtual servicioTienda = new ServicioTiendaVirtual();
        private IServicioCategoria servicioCategoria = new ServicioCategoria();
        // GET: Mueble
        public ActionResult Index()
        {
            return View(servicioMueble.Listar());
        }

        public ActionResult Create()
        {
            ViewBag.tienda = servicioTienda.Listar();
            ViewBag.categoria = servicioCategoria.Listar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Mueble mueble)
        {
            bool rptainsert = servicioMueble.Insertar(mueble);

            if (rptainsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int CMueble)
        {
            ViewBag.tienda = servicioTienda.Listar();
            ViewBag.categoria = servicioCategoria.Listar();
            var mueble = servicioMueble.Listar()
                              .Where(t => t.CodMueble == CMueble)
                              .FirstOrDefault();

            return View(mueble);
        }

        [HttpPost]
        public ActionResult Edit(Mueble mueble)
        {
            var r = mueble.CodMueble > 0 ?
                  servicioMueble.Actualizar(mueble) :
                  servicioMueble.Insertar(mueble);

            if (!r)
            {
                ViewBag.Message = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CMueble)
        {
            var mueble = servicioMueble.Listar()
                               .Where(t => t.CodMueble == CMueble)
                               .FirstOrDefault();

            servicioMueble.Eliminar(mueble);

            return RedirectToAction("Index");
        }
    }
}