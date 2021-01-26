using Capa_de_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class LogicaProfesor : logicaBase
    {
        public bool Actualizar(int IdDato, object NuevosDatos)
        {
            bool respuesta=ProfesoresDal.GetInstance.Actualizar(IdDato, NuevosDatos);
            return respuesta;
        }

        public bool Borrar(int IdDato)
        {
            return ProfesoresDal.GetInstance.EliminarDatos(IdDato);
        }

        public bool Insertar(object datoAInsertar)
        {
            bool respuesta = ProfesoresDal.GetInstance.InsertarDatos(datoAInsertar);
            return respuesta;
        }

        public object Listar()
        {
            return ProfesoresDal.GetInstance.Listar();
        }
    }
}
