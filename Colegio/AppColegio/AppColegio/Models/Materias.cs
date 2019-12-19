using System;
using System.Collections.Generic;

namespace AppColegio.Models
{
    public partial class Materias
    {
        public int Idmaterias { get; set; }
        public int Idcurso { get; set; }
        public string Profesor { get; set; }
        public string NombreMateria { get; set; }
        public string Horario { get; set; }

        public Curso IdcursoNavigation { get; set; }
    }
}
