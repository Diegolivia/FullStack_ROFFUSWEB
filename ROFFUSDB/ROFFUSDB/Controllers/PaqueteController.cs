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
    public class PaqueteController : Controller
    {
        private IServicioPaquete servicioPaquete = new ServicioPaquete();
        // GET: Paquete
        public ActionResult Index()
        {
            return View(servicioPaquete.Listar());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Paquete Paquete)
        {
            bool rptainsert = servicioPaquete.Insertar(Paquete);

            if (rptainsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int CPaquete)
        {
            var Paquete = servicioPaquete.Listar()
                            .Where(t => t.CodPaquete == CPaquete)
                            .FirstOrDefault();

            return View(Paquete);
        }

        [HttpPost]
        public ActionResult Edit(Paquete Paquete)
        {
            var r = Paquete.CodPaquete > 0 ?
                servicioPaquete.Actualizar(Paquete) :
                servicioPaquete.Insertar(Paquete);

            if (!r)
            {
                ViewBag.Message = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CPaquete)
        {
            var Paquete = servicioPaquete.Listar()
                               .Where(t => t.CodPaquete == CPaquete)
                               .FirstOrDefault();

            servicioPaquete.Eliminar(Paquete);

            return RedirectToAction("Index");
        }
    }
}