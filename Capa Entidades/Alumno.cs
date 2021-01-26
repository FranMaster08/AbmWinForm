using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Alumno:Persona
    {

        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public List<Materias> MateriasCursadas { get; set; }
    }
}
