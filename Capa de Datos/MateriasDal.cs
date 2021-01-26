using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Datos
{
    public class MateriasDal : DataAccessLayerBase
    {
        private static MateriasDal instance;
        public static MateriasDal GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MateriasDal();
                }
                return instance;
            }
        }

        private MateriasDal()
        {
            Listar();
        }


        public bool InsertarDatos(object materia)
        {
            try
            {
                int respuesta = 0;
                Materias DatosInsert = (Materias)materia;
                int activo = DatosInsert.Activa ? 1 : 0;
                respuesta = Conexion.GetInstance.Escribir($"INSERT INTO `MATERIAS` (`Descripcion`," +
                    $" `AnioCurso`, `Activa`) VALUES ('{DatosInsert.Descripcion}', '{DatosInsert.AnioCursado}', '{activo}')");
                if (respuesta > 0)
                {
                    return true;

                }
                return false;
            }
            catch (Exception e)
            {

                return false;
            }

        }

        public object Listar()
        {
            try
            {
                DataTable Materiases = Conexion.GetInstance.Leer("SELECT * FROM MATERIAS");
                //copiado StackOverFlow ,Permite Transformar DataTable en Listas
                if (Materiases != null)
                {
                    var empList = Materiases.AsEnumerable()
                      .Select(dataRow => new Materias
                      {
                          Descripcion = dataRow.Field<string>("Descripcion"),
                          AnioCursado = dataRow.Field<int>("AnioCurso"),
                          Id = dataRow.Field<int>("Id"),
                          Activa = dataRow.Field<bool>("Activa")
                       
                      }).ToList();
                    return empList;
                }
                return new List<Materias>();
            }
            catch (Exception e)
            {

                return null;
            }

        }

        public bool EliminarDatos(int IdDato)
        {
            try
            {
                int respuesta = 0;
                respuesta = Conexion.GetInstance.Escribir($"DELETE FROM MATERIAS WHERE Id ={IdDato}");
                if (respuesta > 0)
                {
                    return true;

                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Actualizar(int IdDato, object datosNuevos)
        {
            try
            {
                int respuesta = 0;
                Materias DatosInsert = (Materias)datosNuevos;
                int activo = DatosInsert.Activa ? 1 : 0;
                respuesta = Conexion.GetInstance.Escribir($"UPDATE `tpcuarentena`.`materias` SET `Descripcion` = " +
                    $"'{DatosInsert.Descripcion}', `AnioCurso` = '{DatosInsert.AnioCursado}', `Activa` = {activo} " +
                    $"WHERE (`ID` = {IdDato});" );
                  if (respuesta > 0)
                {
                    return true;

                }
                return false;
            }
            catch (Exception e)
            {

                return false;
            }
        }


        public bool InsertarRelacionProfesor(int idMateria,int ProfesorLegajo)
        {
            try
            {
                int respuesta = 0;
               
              
                respuesta = Conexion.GetInstance.Escribir($"INSERT INTO `profesormateria`(`Plegajo`,`IdMateria`)" +
                    $"VALUES ({ProfesorLegajo},{idMateria}) ");
                if (respuesta > 0)
                {
                    return true;

                }
                return false;
            }
            catch (Exception e)
            {

                return false;
            }

        }


        public object ListarMateriasProfesor(int ProfesorLegajo)
        {
            try
            {
                DataTable Materiases = Conexion.GetInstance.Leer($"select distinct IdMateria, Descripcion,Activa from profesormateria a " +
                    $"join materias b on " +
                    $"a.IdMateria =" +
                    $" b.ID where a.Plegajo = {ProfesorLegajo}");
                //copiado StackOverFlow ,Permite Transformar DataTable en Listas
                if (Materiases != null)
                {
                    var empList = Materiases.AsEnumerable()
                      .Select(dataRow => new Materias
                      {
                          Id= dataRow.Field<int>("IdMateria"),
                          Descripcion = dataRow.Field<string>("Descripcion"),
                          Activa = dataRow.Field<bool>("Activa")

                      }).ToList();
                    return empList;
                }
                return new List<Materias>();
            }
            catch (Exception e)
            {

                return null;
            }

        }

        public bool InsertarRelacionAlumno(int idMateria, int AlumnoLegajo)
        {
            try
            {
                int respuesta = 0;


                respuesta = Conexion.GetInstance.Escribir($"INSERT INTO `Alumnomateria`(`Alegajo`,`IdMateria`)" +
                    $"VALUES ({AlumnoLegajo},{idMateria}) ");
                if (respuesta > 0)
                {
                    return true;

                }
                return false;
            }
            catch (Exception e)
            {

                return false;
            }

        }


        public object ListarMateriasAlumno(int AlumnoLegajo)
        {
            try
            {
                DataTable Materiases = Conexion.GetInstance.Leer($"select distinct IdMateria, Descripcion,Activa from alumnomateria a " +
                    $"join materias b on " +
                    $"a.IdMateria =" +
                    $" b.ID where a.Alegajo = {AlumnoLegajo}");
                //copiado StackOverFlow ,Permite Transformar DataTable en Listas
                if (Materiases != null)
                {
                    var empList = Materiases.AsEnumerable()
                      .Select(dataRow => new Materias
                      {
                          Id = dataRow.Field<int>("IdMateria"),
                          Descripcion = dataRow.Field<string>("Descripcion"),
                          Activa = dataRow.Field<bool>("Activa")

                      }).ToList();
                    return empList;
                }
                return new List<Materias>();
            }
            catch (Exception e)
            {

                return null;
            }

        }


        public bool EliminarRelacionAlumnoDatos(int Materia,int IdAlumno)
        {
            try
            {
                int respuesta = 0;
                respuesta = Conexion.GetInstance.Escribir($"DELETE FROM alumnomateria WHERE IdMateria ={Materia} and Alegajo={IdAlumno}");
                if (respuesta > 0)
                {
                    return true;

                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool EliminarRelacionProfesorDatos(int Materia, int IdProfesor)
        {
            try
            {
                int respuesta = 0;
                respuesta = Conexion.GetInstance.Escribir($"DELETE FROM profesormateria WHERE IdMateria ={Materia} and Plegajo={IdProfesor}");
                if (respuesta > 0)
                {
                    return true;

                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }

    }
}
