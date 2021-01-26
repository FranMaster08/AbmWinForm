using Capa_Entidades;
using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionEscuela.PopUp
{
    public partial class InsertarAlumno : PopUpPersonasBase
    {
        LogicaAlumno logica = new LogicaAlumno();
        public InsertarAlumno()
        {
            InitializeComponent();
        
        }

  

        private void button1_Click_1(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.Nombre = textBox1.Text;
            alumno.Apellido = textBox2.Text;
            alumno.Dni = int.Parse(textBox3.Text.Trim());
            alumno.FechaNacimiento = dateTimePicker1.Value;
            alumno.FechaIngreso = dateTimePicker2.Value;
            alumno.FechaEgreso = dateTimePicker3.Value;
            bool Respuesta = logica.Insertar(alumno);

            if (Respuesta)
            {
                MessageBox.Show(this, $"El alumno {alumno.Nombre} {alumno.Apellido},\nfue agregado con exito.",
                    "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(this, $"No se pudo Insertar Alumno",
                    "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
