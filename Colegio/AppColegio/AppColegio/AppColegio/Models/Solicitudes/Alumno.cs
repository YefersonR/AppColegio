using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppColegio.Models.Solicitudes
{
    public class Alumno
    {
        public int Idcurso { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

    }
}
