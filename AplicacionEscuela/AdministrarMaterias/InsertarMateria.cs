using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionEscuela.AdministrarMaterias
{
    public partial class InsertarMateria : PopUp.PopUpPersonasBase
    {
        #region Sacar Despues
        public static int contLegajo = 1;
        #endregion

        public Capa_Logica.LogicaMaterias logica { get; set; }
        public InsertarMateria()
        {
            InitializeComponent();
            logica = new Capa_Logica.LogicaMaterias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Materias materia = new Materias();
            materia.Id = contLegajo;
            materia.Descripcion = textBox1.Text;
            materia.Activa = checkBox1.Checked;
            materia.AnioCursado = int.Parse(textBox2.Text.Trim());                       
         
            bool Respuesta = logica.Insertar(materia);
            contLegajo++;
            if (Respuesta)
            {
                MessageBox.Show(this, $"La materia {materia.Descripcion},\nfue agregado con exito.",
                    "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(this, $"No se pudo Insertar Materias",
                    "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
