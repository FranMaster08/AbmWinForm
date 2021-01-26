using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Capa_de_Datos
{
    public class ProfesoresDal : DataAccessLayerBase
    {
        private static ProfesoresDal instance;
        public static ProfesoresDal GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProfesoresDal();
                }
                return instance;
            }
        }

        private ProfesoresDal()
        {
            DataTable Profesores=Conexion.GetInstance.Leer("SELECT * FROM PROFESOR");
        }     

        public bool InsertarDatos(object profesor)
        {
            try
            {
                int respuesta = 0;
                Profesor DatosInsert = (Profesor)profesor;
                respuesta = Conexion.GetInstance.Escribir($"INSERT INTO PROFESOR (`Nombre`, `Apellido`, `Fechanacimiento`, `Dni`, `PLegajo`, `FechaDeIngreso`, `Activo`)   VALUES ('{DatosInsert.Nombre}'," +
                    $"'{DatosInsert.Apellido}','{DatosInsert.FechaNacimiento.ToString("yyyyMMdd")}',{DatosInsert.Dni},{DatosInsert.NumeroLegajo}," +
                    $"'{DatosInsert.FechaIngreso.ToString("yyyyMMdd")}',{DatosInsert.Activo})");
                if (respuesta > 0)
                {
                    return true;

                }
                return false;
            }
            catch (Exception e)            {

                return false;
            }
       
        }

        public object Listar()
        {
            try
            {
                DataTable Profesores = Conexion.GetInstance.Leer("SELECT * FROM PROFESOR");
                //copiado StackOverFlow ,Permite Transformar DataTable en Listas
                if (Profesores != null)
                {
                    var empList = Profesores.AsEnumerable()
                      .Select(dataRow => new Profesor
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Apellido = dataRow.Field<string>("Apellido"),
                          Dni = dataRow.Field<int>("Dni"),
                          FechaIngreso = dataRow.Field<DateTime>("FechaDeIngreso"),
                          FechaNacimiento = dataRow.Field<DateTime>("Fechanacimiento"),
                          NumeroLegajo = dataRow.Field<int>("PLegajo"),
                          Activo= dataRow.Field<bool>("Activo")
                      }).ToList();
                    return empList;
                }
                return new List<Profesor>();
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
                respuesta = Conexion.GetInstance.Escribir($"DELETE FROM PROFESOR WHERE PLEGAJO ={IdDato}");
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
                Profesor DatosInsert = (Profesor)datosNuevos;
                int activo = DatosInsert.Activo ? 1 : 0;
                respuesta = Conexion.GetInstance.Escribir($"update PROFESOR set nombre='{DatosInsert.Nombre}'," +
                    $"apellido='{DatosInsert.Apellido}',Fechanacimiento='{DatosInsert.FechaNacimiento.ToString("yyyyMMdd")}',Dni={DatosInsert.Dni}," +
                    $"FechaDeIngreso='{DatosInsert.FechaIngreso.ToString("yyyyMMdd")}',Activo={activo}" +
                    $" where PLegajo={IdDato}");
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
