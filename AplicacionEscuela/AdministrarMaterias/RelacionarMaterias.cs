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
    public partial class RelacionarMaterias : Form
    {
        public int legajoPasado { get; set; }
        public TipoPersona tipoPasado { get; set; }
        public Materias MateriasSeleccionada { get; set; }
        public RelacionarMaterias(int Filtro,TipoPersona tipo)
        {
            InitializeComponent();
            LlenarComboMaterias();
            legajoPasado = Filtro;
            tipoPasado = tipo;
            ListarDatos(Filtro, tipo);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool respuesta;
            if (((Materias)comboBox1.SelectedItem).Activa)
            {

                int IdMateriaSeleccionada = ((Materias)comboBox1.SelectedItem).Id;
               
                switch (tipoPasado)
                {
                    case TipoPersona.Alumno:
                        respuesta = new LogicaMaterias().InsertarRelacionAlumno(IdMateriaSeleccionada, legajoPasado);
                        break;
                    case TipoPersona.Profesor:
                        respuesta = new LogicaMaterias().InsertarRelacionProfesor(IdMateriaSeleccionada, legajoPasado);
                        break;
                    default:
                        return;
                    
                }
                
                if (!respuesta)
                {
                    MessageBox.Show("No se Agrego Relacion");
                }
                ListarDatos(legajoPasado, tipoPasado);
            }
            else
            {
                MessageBox.Show("Solo se pueden Relacionar Materias Activas");
            }
           
        }

        public void ListarDatos(int Filtro, TipoPersona tipo)
        {
            List<Materias> lista = new List<Materias>();
            switch (tipo)
            {
                case TipoPersona.Alumno:
                    lista = (List<Materias>)new LogicaMaterias()
                     .ListarRelacionAlumno(Filtro);
                    break;
                case TipoPersona.Profesor:
                    lista=(List<Materias>)new LogicaMaterias()
                        .ListarRelacionProfesor(Filtro);
                    break;
                default:
                    break;
            }
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = lista;

        }

        public void LlenarComboMaterias()
        {
            List<Materias> Materia = (List<Materias>)new Capa_Logica.LogicaMaterias().Listar();
            this.comboBox1.DataSource = Materia;
            this.comboBox1.DisplayMember = "Descripcion";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool respuesta;
            switch (this.tipoPasado)
            {
                case TipoPersona.Alumno:
                    respuesta = new LogicaMaterias()
                     .EliminarRelacionAlumnoDatos(MateriasSeleccionada.Id,legajoPasado);
                    break;
                case TipoPersona.Profesor:
                    respuesta = new LogicaMaterias()
                        .EliminarRelacionProfesorDatos(MateriasSeleccionada.Id, legajoPasado);
                    break;
                default:
                    break;
            }
            ListarDatos(legajoPasado, tipoPasado);
        }

   

        private void CargarDatosSeleccionados(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    MateriasSeleccionada = new Materias();
                    MateriasSeleccionada.Id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    MateriasSeleccionada.Descripcion = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
