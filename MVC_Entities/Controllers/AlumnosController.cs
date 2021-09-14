using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_Entities.Models;

namespace MVC_Entities.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {

            //Ites_serverEntities db = new Ites_serverEntities();
            try
            {
                using (var db = new Ites_serverEntities())
                {
                    //List<alumno> = db.alumno.Where(a => a.apellido=="Parametro").Tolist();
                    //return View(lista);
                    return View(db.alumno.ToList());
                }

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult ListadoAlumnoCLS()
        {
            List<alumnocls> lista_Alumnos = null;
            using (var db = new Ites_serverEntities()) 
            {
                lista_Alumnos = (from alumno in db.alumno
                                 select new alumnocls
                                 {
                                     id_alumno = alumno.id_alumno,
                                     apellido = alumno.apellido,
                                     nombre = alumno.nombre,
                                     domicilio = alumno.domicilio,
                                     mail = alumno.mail,
                                     edad = alumno.edad,
                                     telefono = alumno.telefono
                                     //id_ciudad = alumno.id_ciudad

                                 }).ToList();
            }

            return View(lista_Alumnos);
            
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        /*----------------------AGREGAR ALUMNO------------------------*/

        public ActionResult Agregar(alumno a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new Ites_serverEntities())
                {
                    db.alumno.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AL INGRESAR ALUMNO", ex);
                return RedirectToAction("Index");
            }
        }

        /*----------------------ELIMINAR ALUMNO------------------------*/

        public ActionResult Eliminar(int id) {
            try
            {
                using (var db = new Ites_serverEntities())
                {
                    alumno alu = db.alumno.Find(id);
                    db.alumno.Remove(alu);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR AL INTENTAR ELIMINAR ALUMNO", ex);
                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        /*----------------------DETALLE ALUMNO------------------------*/


        public ActionResult Detalle(int id)
        {
            try
            {
                using (var db = new Ites_serverEntities())
                {
                    alumno alu = db.alumno.Find(id);
                    return View(alu);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR AL MOSTRAR DETALLES DEL ALUMNO", ex);
                
            }
            return RedirectToAction("Index");
        }

        /*----------------------EDITAR ALUMNO------------------------*/
        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new Ites_serverEntities())
                {
                    alumno alu = db.alumno.Find(id);

                    return View(alu);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Editar(alumno a) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new Ites_serverEntities())
                {
                    alumno alu = db.alumno.Find(a.id_alumno);
                    alu.apellido = a.apellido;
                    alu.nombre = a.nombre;
                    alu.mail = a.mail;
                    alu.telefono = a.telefono;
                    alu.id_ciudad = a.id_ciudad;
                    alu.edad = a.edad;

                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error al editar el alumno", ex);
            }

            return View();
        }

    }
}
