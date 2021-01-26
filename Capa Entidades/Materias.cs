using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Materias
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int  AnioCursado { get; set; }
        public bool Activa { get; set; }

        public List<Profesor> DictadaPor { get; set; }

        public List<Alumno> CursadaPor { get; set; }


    }
}
