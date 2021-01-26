using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public interface logicaBase
    {
         bool Insertar(object datoAInsertar);
         bool Borrar(int IdDato);
         bool Actualizar(int IdDato, object NuevosDatos);
         object Listar();

    }
}
