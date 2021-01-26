using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Datos
{
    public class AlumnosDal:DataAccessLayerBase
    {
        private static AlumnosDal instance;
        public static AlumnosDal GetInstance
        {
            get
            {
                if (instance==null)
                {
                    instance = new AlumnosDal();
                }
                return instance;
            }
        }

        private AlumnosDal()
        {
            Listar();
        }



        public bool InsertarDatos(object alumno)
        {
            try
            {
                int respuesta = 0;
                Alumno DatosInsert = (Alumno)alumno;
                respuesta = Conexion.GetInstance.Escribir($"INSERT INTO ALUMNO (`Nombre`, `Apellido`, `Fechanacimiento`, `Dni`, `ALegajo`, `FechaDeIngreso`,FechaDeEgreso )   VALUES ('{DatosInsert.Nombre}'," +
                    $"'{DatosInsert.Apellido}','{DatosInsert.FechaNacimiento.ToString("yyyyMMdd")}',{DatosInsert.Dni},{DatosInsert.NumeroLegajo}," +
                    $"'{DatosInsert.FechaIngreso.ToString("yyyyMMdd")}',{DatosInsert.FechaEgreso.ToString("yyyyMMdd")})");
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
                DataTable Alumno = Conexion.GetInstance.Leer("SELECT * FROM ALUMNO");
                //copiado StackOverFlow ,Permite Transformar DataTable en Listas
                if (Alumno != null)
                {
                    var empList = Alumno.AsEnumerable()
                      .Select(dataRow => new Alumno
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Apellido = dataRow.Field<string>("Apellido"),
                          Dni = dataRow.Field<int>("Dni"),
                          FechaIngreso = dataRow.Field<DateTime>("FechaDeIngreso"),
                          FechaEgreso = dataRow.Field<DateTime>("FechaDeEgreso"),
                          FechaNacimiento = dataRow.Field<DateTime>("Fechanacimiento"),
                          NumeroLegajo = dataRow.Field<int>("ALegajo")
                     
                      }).ToList();
                    return empList;
                }
                return new List<Alumno>();
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
                respuesta = Conexion.GetInstance.Escribir($"DELETE FROM ALUMNO WHERE ALEGAJO ={IdDato}");
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
                Alumno DatosInsert = (Alumno)datosNuevos;
                 respuesta = Conexion.GetInstance.Escribir($"update ALUMNO set nombre='{DatosInsert.Nombre}'," +
                    $"apellido='{DatosInsert.Apellido}',Fechanacimiento='{DatosInsert.FechaNacimiento.ToString("yyyyMMdd")}',Dni={DatosInsert.Dni}," +
                    $"FechaDeIngreso='{DatosInsert.FechaIngreso.ToString("yyyyMMdd")}'," +
                    $"FechaDeEgreso='{DatosInsert.FechaEgreso.ToString("yyyyMMdd")}'" +
                    $" where ALegajo={IdDato}");
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
    }
}
