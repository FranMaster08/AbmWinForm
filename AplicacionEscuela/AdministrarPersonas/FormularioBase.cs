using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionEscuela
{
    public partial class FormularioBase : Form
    {
        public FormularioBase()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        public virtual void Insertar(){}

        protected void CambiarImagen(string RutaRelativaImagen)
        {
            //Ubicacion fisica del Proyecto
            string rutaActual = Directory.GetCurrentDirectory();
            var imagen = Image.FromFile(Path.GetFullPath(Path.Combine(rutaActual, RutaRelativaImagen)));
            pictureBox1.Image = imagen;
        }

        private void ValidacionNumerica(object sender, EventArgs e)
        {
           //Agregar Validación

        }
    }
}
