using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppColegio.Models.Solicitudes
{
    public class EditMateria
    {
        public int Idmaterias { get; set; }
        public int Idcurso { get; set; }
        public string Profesor { get; set; }
        public string NombreMateria { get; set; }
        public string Horario { get; set; }

    }
}
