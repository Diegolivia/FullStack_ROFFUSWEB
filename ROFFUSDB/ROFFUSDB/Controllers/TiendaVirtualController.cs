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
    public class TiendaVirtualController : Controller
    {
        private IServicioTiendaVirtual servicioTiendaVirtual = new ServicioTiendaVirtual();
        // GET: TiendaVirtual
        public ActionResult Index()
        {
            return View(servicioTiendaVirtual.Listar());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TiendaVirtual tiendavirtual)
        {
            bool rptainsert = servicioTiendaVirtual.Insertar(tiendavirtual);

            if (rptainsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int CTienda)
        {
            var tiendavirtual = servicioTiendaVirtual.Listar()
                              .Where(t => t.CodTienda == CTienda)
                              .FirstOrDefault();

            return View(tiendavirtual);
        }

        [HttpPost]
        public ActionResult Edit(TiendaVirtual tiendavirtual)
        {
            var r = tiendavirtual.CodTienda > 0 ?
                  servicioTiendaVirtual.Actualizar(tiendavirtual) :
                  servicioTiendaVirtual.Insertar(tiendavirtual);

            if (!r)
            {
                ViewBag.Message = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CTienda)
        {
            var tiendavirtual = servicioTiendaVirtual.Listar()
                               .Where(t => t.CodTienda == CTienda)
                               .FirstOrDefault();

            servicioTiendaVirtual.Eliminar(tiendavirtual);

            return RedirectToAction("Index");
        }

    }
}