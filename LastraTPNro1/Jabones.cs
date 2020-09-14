using System;
using System.Windows.Forms;
using Negocio;
using BE;
using System.Drawing;

namespace LastraTPNro1
{
    public partial class Jabones : Form
    {
        public Jabones()
        {
            InitializeComponent();
            CargarGrilla();
        }

        #region Varaibles
        BE.Jabones Bjabones =  new BE.Jabones();
        Negocio.Jabones nJabones;
        #endregion

        #region Metodos de los controles del Form

        private void button4_Click(object sender, EventArgs e)
        {
            //Return home
            Hide();
            Gestion gestion = new Gestion();
            gestion.Show();
        }
        
        private void btAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                nJabones = new Negocio.Jabones();
                nJabones.Insert(Bjabones);
                CargarGrilla();
                tbCantidad.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Asignar();
            nJabones = new Negocio.Jabones();
            nJabones.Update(Bjabones);
            CargarGrilla();
            tbCantidad.Text = "";
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Asignar();
            nJabones = new Negocio.Jabones();
            nJabones.Delete(Bjabones);
            CargarGrilla();
            tbCantidad.Text = "";
        }

        #endregion

        #region Metodos mios
        protected void Asignar()
        {
            Bjabones = new BE.Jabones
            {
                Id = Int32.Parse(tbCodigo.Text),
                Aroma = cbAroma.Text,
                Base = cbBase.Text,
                Color = cbColor.Text,
                Cantidad = Int32.Parse(tbCantidad.Text)
            };
        }

        void CargarGrilla()
        {
            Negocio.Jabones Jabon = new Negocio.Jabones();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Jabon.CargarJabones();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Coral;
            //dataGridView1.Columns[""].HeaderText = "asdasd";
        }
        #endregion
    }
}
