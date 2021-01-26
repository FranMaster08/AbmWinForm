using AplicacionEscuela.AdministrarMaterias;
using AplicacionEscuela.PopUp;
using Capa_Entidades;
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
    public partial class AdministrarAlumnos : FormularioBase
    {
        public Alumno  AlumnoSeleccionado { get; set; }
        public Capa_Logica.LogicaAlumno LogicaAlumno { get; set; }
        public AdministrarAlumnos()
        {
            InitializeComponent();
            CambiarImagen(@".\..\..\imagenes\Alumno.png");
            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            LogicaAlumno = new Capa_Logica.LogicaAlumno();
            ListarDatos();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    string Legajo = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    this.dateTimePicker2.Value = (DateTime)dataGridView1.SelectedRows[0].Cells[0].Value;
                    this.dateTimePicker3.Value = (DateTime)dataGridView1.SelectedRows[0].Cells[1].Value;
                    this.textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    this.textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    this.dateTimePicker1.Value = (DateTime)dataGridView1.SelectedRows[0].Cells[5].Value;
                    this.textBox3.Text = ((int)dataGridView1.SelectedRows[0].Cells[6].Value).ToString();
                    this.textBox6.Text = Legajo;
                    AlumnoSeleccionado = new Alumno();
                    AlumnoSeleccionado.Nombre = textBox1.Text;
                    AlumnoSeleccionado.Apellido = textBox2.Text;
                    AlumnoSeleccionado.Dni = int.Parse(textBox3.Text.Trim());
                    AlumnoSeleccionado.FechaNacimiento = dateTimePicker1.Value;
                    AlumnoSeleccionado.FechaIngreso = dateTimePicker2.Value;
                    AlumnoSeleccionado.NumeroLegajo = int.Parse(Legajo);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public override void Insertar()
        {
            InsertarAlumno insertarAlumno = new InsertarAlumno();
            insertarAlumno.ShowDialog();
            ListarDatos();
        }

  


        private void button4_Click(object sender, EventArgs e)
        {

            if (AlumnoSeleccionado != null )
            {

                RelacionarMaterias materias = new RelacionarMaterias(this.AlumnoSeleccionado.NumeroLegajo,TipoPersona.Alumno);
                materias.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Selecciono un Alumno activo");
            }

        }

        public void ListarDatos(List<Alumno> listaFiltrada = null)
        {
            List<Alumno> alumnos = new List<Alumno>();
            if (listaFiltrada == null)
                alumnos = (List<Alumno>)LogicaAlumno.Listar();
            else
                if (listaFiltrada.Count > 0)
                alumnos = listaFiltrada;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = alumnos;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            switch (this.comboBox1.SelectedIndex)
            {
                case 1:
                    Alumno NuevosDatos = new Alumno();
                    NuevosDatos.Nombre = this.textBox1.Text;
                    NuevosDatos.Apellido = this.textBox2.Text;
                    NuevosDatos.FechaNacimiento = this.dateTimePicker1.Value;
                    NuevosDatos.FechaIngreso = this.dateTimePicker2.Value;
                    NuevosDatos.FechaEgreso = this.dateTimePicker3.Value;
                    NuevosDatos.Dni = int.Parse(this.textBox3.Text);
                    NuevosDatos.NumeroLegajo = int.Parse(this.textBox6.Text);
                    bool respuesta = LogicaAlumno.Actualizar(NuevosDatos.NumeroLegajo, NuevosDatos);
                    if (respuesta)
                    {
                        MessageBox.Show(this, $"Se actualizo el Profesor { NuevosDatos.Nombre }", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, $"No se actualizo el Profesor { NuevosDatos.Nombre }", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    DialogResult dialogResult = MessageBox.Show(this, $"¿Esta Seguro que deseas eliminar al Profesor: { this.textBox1.Text }?", "Exito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                    bool respuesta2 = LogicaAlumno.Borrar(int.Parse(this.textBox6.Text));
                    if (respuesta2)
                    {
                        MessageBox.Show(this, $"Se Elimino el Profesor { this.textBox1.Text}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, $"No se Elimino el Profesor { this.textBox1.Text }", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       private void button2_Click_1(object sender, EventArgs e)
        {
            List<Alumno> alumnosFiltro = null;
            int? valorDni = null;

            if (!string.IsNullOrEmpty(textBox4.Text))
                valorDni = int.Parse(textBox4.Text);
            List<Alumno> alumnos = (List<Alumno>)LogicaAlumno.Listar();

            if (valorDni == null && string.IsNullOrEmpty(textBox5.Text))
            {
                ListarDatos();
                return;
            }

            foreach (var item in alumnos)
            {
                if (item.Dni == valorDni.GetValueOrDefault(0) || item.Apellido == textBox5.Text)
                {
                    if (alumnosFiltro == null)
                        alumnosFiltro = new List<Alumno>();
                    alumnosFiltro.Add(item);
                }
            }

            ListarDatos(alumnosFiltro);

        }

      
    }
}
