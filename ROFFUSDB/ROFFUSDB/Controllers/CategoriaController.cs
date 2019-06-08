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
    public class CategoriaController : Controller
    {
        private IServicioCategoria servicioCategoria = new ServicioCategoria();
        // GET: Categoria
        public ActionResult Index()
        {
            return View(servicioCategoria.Listar());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            bool rptainsert = servicioCategoria.Insertar(categoria);

            if (rptainsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int CCategoria)
        {
            var categoria = servicioCategoria.Listar()
                            .Where(t => t.CodCategoria == CCategoria)
                            .FirstOrDefault();

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            var r = categoria.CodCategoria > 0 ?
                servicioCategoria.Actualizar(categoria) :
                servicioCategoria.Insertar(categoria);

            if (!r)
            {
                ViewBag.Message = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CCategoria)
        {
            var categoria = servicioCategoria.Listar()
                               .Where(t => t.CodCategoria == CCategoria)
                               .FirstOrDefault();

            servicioCategoria.Eliminar(categoria);

            return RedirectToAction("Index");
        }
    }
}