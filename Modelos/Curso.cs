using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Modelos
{
    public class Curso
    {
        public int Id { get; set; }
        public string NobreCurso { get; set; }
        public int CantidadClases { get; set; }
        public int Precio { get; set; }
    }
}
