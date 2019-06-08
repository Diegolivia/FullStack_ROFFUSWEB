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
    public class PlantillaController : Controller
    {
        private IServicioPlantilla servicioPlantilla = new ServicioPlantilla();
        // GET: Plantilla
        public ActionResult Index()
        {
            return View(servicioPlantilla.Listar());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Plantilla plantilla)
        {
            bool rptainsert = servicioPlantilla.Insertar(plantilla);

            if (rptainsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int CPlantilla)
        {
            var plantilla = servicioPlantilla.Listar()
                              .Where(t => t.CodPlantilla == CPlantilla)
                              .FirstOrDefault();

            return View(plantilla);
        }

        [HttpPost]
        public ActionResult Edit(Plantilla plantilla)
        {
            var r = plantilla.CodPlantilla > 0 ?
                  servicioPlantilla.Actualizar(plantilla) :
                  servicioPlantilla.Insertar(plantilla);

            if (!r)
            {
                ViewBag.Message = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CPlantilla)
        {
            var plantilla = servicioPlantilla.Listar()
                               .Where(t => t.CodPlantilla == CPlantilla)
                               .FirstOrDefault();

            servicioPlantilla.Eliminar(plantilla);

            return RedirectToAction("Index");
        }

    }
}