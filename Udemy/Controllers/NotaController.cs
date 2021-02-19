using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy.Models;

namespace Udemy.Controllers
{
    public class NotaController : Controller
    {
        // GET: Nota
        public ActionResult Index()
        {
            AlumnosContect db = new AlumnosContect(); 
            return View(db.Nota.ToList());
        }

        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContect())
                {
                    Nota nota = db.Nota.Find(id);
                    return View(nota); ;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Nota a)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new AlumnosContect())
                {
                    Nota nota = db.Nota.Find(a.ID);
                    nota.Materia = a.Materia;
                    nota.Nota1 = a.Nota1;
                    nota.Nota2 = a.Nota2;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult DetallesNota(int id)
        {
            using (var db = new AlumnosContect())
            {
                Nota nota = db.Nota.Find(id);
                return View(nota);
            }
        }
        public ActionResult EliminarNota(int id)
        {
            using (var db = new AlumnosContect())
            {
                Nota nota = db.Nota.Find(id);
                db.Nota.Remove(nota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult ListaAlumnos() 
        {
            using (var db = new AlumnosContect())
            {
                return PartialView(db.Alumno.ToList());
            }
        }

        public ActionResult ListaMaterias()
        {
            using (var db = new AlumnosContect())
            {
                return PartialView(db.Materia.ToList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Nota a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new AlumnosContect())
                {

                    db.Nota.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar nota - " + ex.Message);
                return View();
            }
        }

        public static string NombreAlumno(int IDAlumno)
        {
            using (var db = new AlumnosContect())
            {
                return db.Alumno.Find(IDAlumno).Nombres + " " + db.Alumno.Find(IDAlumno).Apellidos;
            }
        }
        public static string NombreMateria(int IDMateria)
        {
            using (var db = new AlumnosContect())
            {
                return db.Materia.Find(IDMateria).Nombre;
            }
        }
    }
}