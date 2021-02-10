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

            AlumnosContect db = new AlumnosContect();

            return View(db.Alumno.ToList());
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
    }
}