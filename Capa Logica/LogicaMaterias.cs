using Capa_de_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class LogicaMaterias : logicaBase
    {
        public bool Actualizar(int IdDato, object NuevosDatos)
        {
            bool respuesta = MateriasDal.GetInstance.Actualizar(IdDato, NuevosDatos);
            return respuesta;
        }

        public bool Borrar(int IdDato)
        {
            return MateriasDal.GetInstance.EliminarDatos(IdDato);
        }

        public bool Insertar(object datoAInsertar)
        {
            MateriasDal.GetInstance.InsertarDatos(datoAInsertar);
            return true;
        }

        public object Listar()
        {
            return MateriasDal.GetInstance.Listar();
        }


        public bool InsertarRelacionProfesor(int Materia,int ProfesorLegajo)
        {
            return MateriasDal.GetInstance.InsertarRelacionProfesor(Materia, ProfesorLegajo);
        }


        public object ListarRelacionProfesor(int legajo)
        {
            return MateriasDal.GetInstance.ListarMateriasProfesor(legajo);
        }

        public bool InsertarRelacionAlumno(int Materia, int AlumnosLegajo)
        {
            return MateriasDal.GetInstance.InsertarRelacionAlumno(Materia, AlumnosLegajo);
        }


        public object ListarRelacionAlumno(int AlumnosLegajo)
        {
            return MateriasDal.GetInstance.ListarMateriasAlumno(AlumnosLegajo);
        }


        public bool EliminarRelacionAlumnoDatos(int Materia, int IdAlumno)
        {
            return MateriasDal.GetInstance.EliminarRelacionAlumnoDatos( Materia,  IdAlumno);

        }

        public bool EliminarRelacionProfesorDatos(int Materia, int IdProfesor)
        {
            return MateriasDal.GetInstance.EliminarRelacionProfesorDatos(Materia, IdProfesor);

        }


    }
}
