using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class AlumnoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            {
                using (Models.ColegioContext bd = new Models.ColegioContext())
                {
                    var select = (from x in bd.Alumno
                                  select x).ToList();

                    return Ok(select);

                }
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Models.Solicitudes.Alumno alumno)
        {
            using (Models.ColegioContext bd = new Models.ColegioContext())
            {

                Models.Alumno alumnoo = new Models.Alumno();
                alumnoo.Idcurso = alumno.Idcurso;
                alumnoo.Nombre = alumno.Nombre;
                alumnoo.Edad = alumno.Edad;
                alumnoo.Telefono = alumno.Telefono;
                alumnoo.Direccion = alumno.Direccion;
                bd.Alumno.Add(alumnoo);
                bd.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Models.Solicitudes.EditAlumno alumno)
        {
            using (Models.ColegioContext bd = new Models.ColegioContext())
            {
                Models.Alumno alumnoo = bd.Alumno.Find(alumno.Idalumno);
                alumnoo.Idcurso = alumno.Idcurso;
                alumnoo.Nombre = alumno.Nombre;
                alumnoo.Edad = alumno.Edad;
                alumnoo.Telefono = alumno.Telefono;
                alumnoo.Direccion = alumno.Direccion;
                bd.Entry(alumnoo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                bd.SaveChanges();
            }
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Solicitudes.EditAlumno alumno)
        {
            using (Models.ColegioContext bd = new Models.ColegioContext())
            {
                Models.Alumno alumnoo = bd.Alumno.Find(alumno.Idalumno);

                bd.Remove(alumnoo);
                bd.SaveChanges();
            }
            return Ok();
        }
    }
}

