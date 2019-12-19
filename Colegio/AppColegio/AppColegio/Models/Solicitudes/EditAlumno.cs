using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppColegio.Models.Solicitudes
{
    public class EditAlumno
    {
        public int Idalumno { get; set; }
        public int Idcurso { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
