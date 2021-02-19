using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy.Models;

namespace Udemy.Controllers
{
    public class DocenteController : Controller
    {
        // GET: Docente
        public ActionResult Index()
        {
            AlumnosContect db = new AlumnosContect();

            return View(db.Maestro.ToList());
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Maestro a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new AlumnosContect())
                {
                    
                    db.Maestro.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar Maestro - " + ex.Message);
                return View();
            }
        }
        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContect())
                {
                    Maestro maestro = db.Maestro.Find(id);
                    return View(maestro); ;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Maestro a)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new AlumnosContect())
                {
                    Maestro maestro = db.Maestro.Find(a.ID);
                    maestro.Nombres = a.Nombres;
                    maestro.Apellidos = a.Apellidos;
                    maestro.Edad = a.Edad;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult DetallesDocente(int id)
        {
            using (var db = new AlumnosContect())
            {
                Maestro maestro = db.Maestro.Find(id);
                return View(maestro);
            }
        }
        public ActionResult EliminarDocente(int id)
        {
            try
            {
                using (var db = new AlumnosContect())
                {
                    Maestro maestro = db.Maestro.Find(id);
                    db.Maestro.Remove(maestro);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Una materia depende de este docente, no se puede eliminar hasta entonces.");
                return View("Error");
            }
        }

    }
}