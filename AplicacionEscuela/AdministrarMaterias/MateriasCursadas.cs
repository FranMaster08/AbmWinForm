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

namespace AplicacionEscuela.AdministrarMaterias
{
    public partial class MateriasCursadas : Form
    {
        public MateriasCursadas()
        {
            InitializeComponent();
            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            ListarDatos();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    string Legajo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    this.textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    this.textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    this.checkBox1.Checked = (bool)dataGridView1.SelectedRows[0].Cells[3].Value;
                    this.textBox1.Text = Legajo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertarMateria insertarMateria = new InsertarMateria();
            insertarMateria.ShowDialog();
            ListarDatos();
        }
        public void ListarDatos()
        {
            List<Materias> Materia = (List<Materias>)new Capa_Logica.LogicaMaterias().Listar();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = Materia;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (this.comboBox1.SelectedIndex)
            {
                case 1:
                    Materias materia = new Materias();
                    materia.Descripcion = this.textBox3.Text;
                    materia.Activa = this.checkBox1.Checked;
                    materia.AnioCursado = int.Parse(this.textBox4.Text);
                    materia.Id= int.Parse(this.textBox1.Text);
                    bool respuesta = new LogicaMaterias().Actualizar(materia.Id, materia);
                    if (respuesta)
                    {
                        MessageBox.Show(this, $"Se actualizo el Materias { materia.Descripcion }", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, $"No se actualizo el Materias { materia.Descripcion }", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    DialogResult dialogResult = MessageBox.Show(this, $"¿Esta Seguro que deseas eliminar al Materias: { this.textBox1.Text }?", "Exito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                    bool respuesta2 = new LogicaMaterias().Borrar(int.Parse(this.textBox1.Text));
                    if (respuesta2)
                    {
                        MessageBox.Show(this, $"Se Elimino el Materias { this.textBox1.Text}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, $"No se Elimino el Materias { this.textBox1.Text }", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 3:
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
            ListarDatos();
        }
    }
}
