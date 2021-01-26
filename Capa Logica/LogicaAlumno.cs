using Capa_de_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class LogicaAlumno : logicaBase
    {
        public bool Actualizar(int IdDato, object NuevosDatos)
        {
            bool respuesta = AlumnosDal.GetInstance.Actualizar(IdDato, NuevosDatos);
            return respuesta;
        }

        public bool Borrar(int IdDato)
        {
            return AlumnosDal.GetInstance.EliminarDatos(IdDato);
        }

        public bool Insertar(object datoAInsertar)
        {
            bool respuesta = AlumnosDal.GetInstance.InsertarDatos(datoAInsertar);
            return respuesta;
        }

        public object Listar()
        {
            return AlumnosDal.GetInstance.Listar();
        }
    }
}
