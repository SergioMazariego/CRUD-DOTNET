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

                ModelState.AddModelError("", "Error al registrar materia");
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContect())
                {
                    Materia materia = db.Materia.Find(id);
                    return View(materia);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Materia m)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new AlumnosContect())
                {
                    Materia materia = db.Materia.Find(m.ID);
                    materia.Nombre = m.Nombre;
                    materia.IDMaestro = m.IDMaestro;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult EliminarMateria(int id)
        {
            try
            {
                using (var db = new AlumnosContect())
                {
                    Materia materia = db.Materia.Find(id);
                    db.Materia.Remove(materia);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Un alumno depende de esta materia, no se puede eliminar hasta entonces.");
                return View("Error");
            }
        }


        public ActionResult DetallesMateria(int id)
        {
            using (var db = new AlumnosContect())
            {
                Materia materia = db.Materia.Find(id);
                return View(materia);
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