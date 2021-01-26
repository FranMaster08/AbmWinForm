using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Persona
    {
        public int NumeroLegajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Dni { get; set; }

        public int EdadActual => Edad();

        public int Edad()
        {          
            return DateTime.Now.Year - this.FechaNacimiento.Year;
        }

    }
}
