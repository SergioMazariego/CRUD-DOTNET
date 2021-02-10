using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy.Models;

namespace Udemy.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            try
            {
                using (var db = new AlumnosContect())
                {
                    //List<Alumno> lista = db.Alumno.Where(a => a.Edad >= 18).ToList();
                    return View(db.Alumno.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid) {
                return View();
            }

            try
            {
                using (var db = new AlumnosContect())
                {
                    a.FechaRegistro = DateTime.Now;

                    db.Alumno.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar Alumno - " + ex.Message);
                return View();
            }
        }
        public ActionResult Agregar2()
        {
            return View();
        }
        public ActionResult ListaCiudades()
        {
            using (var db = new AlumnosContect())
            {
                return PartialView(db.Ciudad.ToList());            }
        }

        public ActionResult Editar(int id) 
        {
            try
            {
                using (var db = new AlumnosContect())
                {
                    Alumno alu = db.Alumno.Find(id);
                    return View(alu); ;
                }
            }
            catch (Exception ex)
            {

                throw;
            }     
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Alumno a)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new AlumnosContect()) 
                {
                    Alumno al = db.Alumno.Find(a.ID);
                    al.Nombres = a.Nombres;
                    al.Apellidos = a.Apellidos;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;
                    al.CodCiudad = a.CodCiudad;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult Detallesalumno(int id) 
        {
            using (var db = new AlumnosContect())
            {
                Alumno alu = db.Alumno.Find(id);
                return View(alu);
            }
        }
        public ActionResult EliminarAlumno(int id)
        {
            using (var db = new AlumnosContect())
            {
                Alumno alu = db.Alumno.Find(id);
                db.Alumno.Remove(alu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public static string NombreCiudad(int CodCiudad) 
        {
            using (var db = new AlumnosContect())
            {
                return db.Ciudad.Find(CodCiudad).Nombre;
            }
        }
    }
}