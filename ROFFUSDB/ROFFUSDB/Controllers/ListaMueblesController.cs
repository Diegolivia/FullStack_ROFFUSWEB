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
    public class ListaMueblesController : Controller
    {
        private IServicioListaMuebles servicioListaMuebles = new ServicioListaMuebles();
        private IServicioMueble servicioMueble = new ServicioMueble();
        // GET: ListaMuebles
        public ActionResult Index()
        {
            return View(servicioListaMuebles.Listar());
        }

        public ActionResult Create()
        {
            ViewBag.mueble = servicioMueble.Listar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ListaMuebles listamuebles)
        {
            bool rptainsert = servicioListaMuebles.Insertar(listamuebles);

            if (rptainsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int CLista)
        {
            ViewBag.mueble = servicioMueble.Listar();
            var listamueble = servicioListaMuebles.Listar()
                              .Where(t => t.CodLista == CLista)
                              .FirstOrDefault();

            return View(listamueble);
        }

        [HttpPost]
        public ActionResult Edit(ListaMuebles listamuebles)
        {
            var r = listamuebles.CodLista > 0 ?
                  servicioListaMuebles.Actualizar(listamuebles) :
                  servicioListaMuebles.Insertar(listamuebles);

            if (!r)
            {
                ViewBag.Message = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CLista)
        {
            var listamueble = servicioListaMuebles.Listar()
                               .Where(t => t.CodLista == CLista)
                               .FirstOrDefault();

            servicioListaMuebles.Eliminar(listamueble);

            return RedirectToAction("Index");
        }
    }
}