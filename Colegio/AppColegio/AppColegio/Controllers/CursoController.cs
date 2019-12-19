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
    public class CursoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            {
                using (Models.ColegioContext bd = new Models.ColegioContext())
                {
                    var select = (from c in bd.Curso
                                  select c).ToList();

                    return Ok(select);

                }
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Models.Solicitudes.Curso curso)
        {
            using (Models.ColegioContext bd = new Models.ColegioContext())
            {
                Models.Curso cursoo = new Models.Curso();
                cursoo.Nombre = curso.Nombre;
                cursoo.Seccion = curso.Seccion;
                bd.Curso.Add(cursoo);
                bd.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Models.Solicitudes.EditCurso curso)
        {
            using (Models.ColegioContext bd = new Models.ColegioContext())
            {
                Models.Curso cursoo = bd.Curso.Find(curso.Idcurso);
                cursoo.Nombre = curso.Nombre;
                cursoo.Seccion = cursoo.Seccion;
                bd.Entry(cursoo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                bd.SaveChanges();
            }
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Solicitudes.EditCurso curso)
        {
            using (Models.ColegioContext bd = new Models.ColegioContext())
            {
                Models.Curso cursoo = bd.Curso.Find(curso.Idcurso);
                bd.Remove(cursoo);
                bd.SaveChanges();
            }
            return Ok();
        }
    }
}