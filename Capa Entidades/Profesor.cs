using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Profesor:Persona
    {
        public DateTime FechaIngreso { get; set; }
        public List<Materias> MateriasDictadas { get; set; }
        public bool Activo { get; set; }

        public int AniosDocente => AnosComoDocente();

        public int AnosComoDocente()
        {
            return DateTime.Now.Year - FechaIngreso.Year;
        }

    }
}
