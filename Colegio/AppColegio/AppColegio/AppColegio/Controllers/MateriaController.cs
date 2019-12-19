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
    public class MateriaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            {
                using (Models.ColegioContext bd = new Models.ColegioContext())
                {
                    var select = (from c in bd.Materias
                                  select c).ToList();

                    return Ok(select);

                }
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Models.Solicitudes.Materia materia)
        {
            using (Models.ColegioContext bd = new Models.ColegioContext())
            {
                
                Models.Materias materiaa = new Models.Materias();
                materiaa.Idcurso = materia.Idcurso;
                materiaa.Profesor = materia.Profesor;
                materiaa.NombreMateria = materia.NombreMateria;
                materiaa.Horario = materia.Horario;
                bd.Materias.Add(materiaa);
                bd.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Models.Solicitudes.EditMateria materia)
        {
            using (Models.ColegioContext bd = new Models.ColegioContext())
            {
                Models.Materias materiaa = bd.Materias.Find(materia.Idmaterias);
                materiaa.Profesor = materia.Profesor;
                materiaa.NombreMateria = materia.NombreMateria;
                materiaa.Horario = materia.Horario;
                bd.Entry(materiaa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                bd.SaveChanges();
            }
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Solicitudes.EditMateria materia)
        {
            using (Models.ColegioContext bd = new Models.ColegioContext())
            {
                Models.Materias materiaa = bd.Materias.Find(materia.Idmaterias);
                bd.Remove(materiaa);
                bd.SaveChanges();
            }
            return Ok();
        }
    }
}