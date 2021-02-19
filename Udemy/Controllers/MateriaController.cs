using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy.Models;

namespace Udemy.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            AlumnosContect db = new AlumnosContect();

            return View(db.Materia.ToList());
        }
        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult ListaDocentes()
        {
            using (var db = new AlumnosContect())
            {
                return PartialView(db.Maestro.ToList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Materia a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new AlumnosContect())
                {

                    db.Materia.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar materia - " + ex.InnerException);
                return View();
            }
        }

        public static string NombreMaestro(int IDMaestro)
        {
            using (var db = new AlumnosContect())
            {
                return db.Maestro.Find(IDMaestro).Nombres + " " + db.Maestro.Find(IDMaestro).Apellidos;
            }
        }

    }
}