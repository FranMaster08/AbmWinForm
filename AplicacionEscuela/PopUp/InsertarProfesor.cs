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
    public partial class InsertarProfesor : PopUpPersonasBase
    {
        LogicaProfesor logica = new LogicaProfesor();
        public InsertarProfesor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profesor profesor = new Profesor();
            profesor.Nombre = textBox1.Text;
            profesor.Apellido = textBox2.Text;
            profesor.Dni = int.Parse(textBox3.Text.Trim());
            profesor.FechaNacimiento = dateTimePicker1.Value;
            profesor.FechaIngreso = dateTimePicker2.Value;
           bool Respuesta = logica.Insertar(profesor);
          
            if (Respuesta)
            {
                MessageBox.Show(this, $"El profesor {profesor.Nombre} {profesor.Apellido},\nfue agregado con exito.",
                    "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show(this, $"No se pudo Insertar Profesor",
                    "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
