using System;
using System.Collections.Generic;

namespace AppColegio.Models
{
    public partial class Alumno
    {
        public int Idalumno { get; set; }
        public int Idcurso { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public Curso IdcursoNavigation { get; set; }
    }
}
