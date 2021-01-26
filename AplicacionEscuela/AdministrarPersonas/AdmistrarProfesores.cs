using AplicacionEscuela.AdministrarMaterias;
using AplicacionEscuela.PopUp;
using Capa_Entidades;
using Capa_Logica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AplicacionEscuela
{
    public partial class AdmistrarProfesores : FormularioBase
    {
        LogicaProfesor LogicaProfesor = new LogicaProfesor();

        public Profesor ProfesorSeleccionado { get; set; }

        public AdmistrarProfesores()
        {
            InitializeComponent();
            CambiarImagen(@".\..\..\imagenes\Profesor.png");
            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            ListarDatos();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    string Legajo = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    this.checkBox1.Checked = (bool)dataGridView1.SelectedRows[0].Cells[1].Value;
                    this.textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    this.textBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    this.dateTimePicker1.Value = (DateTime)dataGridView1.SelectedRows[0].Cells[6].Value;
                    this.textBox3.Text = ((int)dataGridView1.SelectedRows[0].Cells[7].Value).ToString();
                    this.textBox6.Text = Legajo;
                    this.dateTimePicker2.Value= (DateTime)dataGridView1.SelectedRows[0].Cells[0].Value;
                    ProfesorSeleccionado = new Profesor();
                    ProfesorSeleccionado.Nombre = textBox1.Text;
                    ProfesorSeleccionado.Apellido = textBox2.Text;
                    ProfesorSeleccionado.Dni = int.Parse(textBox3.Text.Trim());
                    ProfesorSeleccionado.FechaNacimiento = dateTimePicker1.Value;
                    ProfesorSeleccionado.FechaIngreso = dateTimePicker2.Value;
                    ProfesorSeleccionado.NumeroLegajo = int.Parse(Legajo);
                    ProfesorSeleccionado.Activo = this.checkBox1.Checked;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public override void Insertar()
        {
            InsertarProfesor VentanaInsertarProfesor = new InsertarProfesor();
            VentanaInsertarProfesor.ShowDialog();
            ListarDatos();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (ProfesorSeleccionado!=null && ProfesorSeleccionado.Activo)
            {

                RelacionarMaterias materias = new RelacionarMaterias(this.ProfesorSeleccionado.NumeroLegajo,TipoPersona.Profesor);
                materias.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Selecciono un Profesor activo");
            }

        }

        public void ListarDatos(List<Profesor> listaFiltrada = null)
        {
            List<Profesor> profesors = new List<Profesor>();
            if (listaFiltrada==null)
                 profesors = (List<Profesor>)LogicaProfesor.Listar();            
            else            
                if (listaFiltrada.Count>0)
                 profesors = listaFiltrada;       
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = profesors;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            switch (this.comboBox1.SelectedIndex)
            {
                case 1:
                    Profesor NuevosDatos = new Profesor();
                    NuevosDatos.FechaIngreso = this.dateTimePicker2.Value;
                    NuevosDatos.Activo = this.checkBox1.Checked;
                    NuevosDatos.Nombre = this.textBox1.Text;
                    NuevosDatos.Apellido = this.textBox2.Text;
                    NuevosDatos.FechaNacimiento = this.dateTimePicker1.Value;
                    NuevosDatos.Dni = int.Parse(this.textBox3.Text);
                    NuevosDatos.NumeroLegajo = int.Parse(this.textBox6.Text);
                    bool respuesta = LogicaProfesor.Actualizar(NuevosDatos.NumeroLegajo, NuevosDatos);
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
                    bool respuesta2 = LogicaProfesor.Borrar(int.Parse(this.textBox6.Text));
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

        private void button2_Click(object sender, EventArgs e)
        {
            List<Profesor> profesorsFiltro = null;
            int? valorDni =null ;
         
            if (!string.IsNullOrEmpty(textBox4.Text))            
                valorDni = int.Parse(textBox4.Text);  
            List<Profesor> profesors = (List <Profesor>) LogicaProfesor.Listar();

            if (valorDni==null &&  string.IsNullOrEmpty(textBox5.Text))
            {
                ListarDatos();
                return;
            }

            foreach (var item in profesors)
            {
                if (item.Dni==valorDni.GetValueOrDefault(0) || item.Apellido==textBox5.Text )
                {
                       if (profesorsFiltro==null)                    
                        profesorsFiltro = new List<Profesor>();                    
                    profesorsFiltro.Add(item);
                }
            }
       
            ListarDatos(profesorsFiltro);

        }
    }
}
