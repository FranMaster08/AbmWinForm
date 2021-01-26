using AplicacionEscuela.AdministrarMaterias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionEscuela
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdmistrarProfesores VistaAlumnos = new AdmistrarProfesores();
            MostrarPantalla(VistaAlumnos);

        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrarAlumnos VistaAlumnos = new AdministrarAlumnos();
            MostrarPantalla(VistaAlumnos);
        }


        public void MostrarPantalla(Form Ventana)
        {
            Ventana.MdiParent = this;
            Ventana.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriasCursadas Materias = new MateriasCursadas();
            MostrarPantalla(Materias);
        }
    }
}
