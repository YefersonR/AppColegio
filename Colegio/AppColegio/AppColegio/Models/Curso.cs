using System;
using System.Collections.Generic;

namespace AppColegio.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Alumno = new HashSet<Alumno>();
            Materias = new HashSet<Materias>();
        }

        public int Idcurso { get; set; }
        public string Nombre { get; set; }
        public string Seccion { get; set; }

        public ICollection<Alumno> Alumno { get; set; }
        public ICollection<Materias> Materias { get; set; }
    }
}
