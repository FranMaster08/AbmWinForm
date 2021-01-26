using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Datos
{
    public interface DataAccessLayerBase
    {
        bool InsertarDatos(object datoaInsertar);
        bool EliminarDatos(int IdDato);
        bool Actualizar(int IdDato,object datosNuevos);

        object Listar();
       

    }
}
