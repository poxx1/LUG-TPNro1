using System;
using System.Windows.Forms;
using System.Drawing;
using BE;

namespace LastraTPNro1
{
    public partial class Jabones : Form
    {
        public Jabones()
        {
            InitializeComponent();
            CargarGrilla();
            lbLOG.ForeColor = Color.Cyan;
            lbLOG.Text = "Aqui se mostraran los cambios que se hagan";
        }

        #region Varaibles
        BE.Jabones Bjabones =  new BE.Jabones();
        BE.NJabones nJabones;
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
                nJabones = new BE.NJabones();
                nJabones.Insert(Bjabones);
                CargarGrilla();
                lbLOG.ForeColor = Color.Green;
                lbLOG.Text = "Se agrego el jabon a la base de datos.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Asignar();
            nJabones = new BE.NJabones();
            nJabones.Update(Bjabones);
            CargarGrilla();
            lbLOG.ForeColor = Color.Green;
            lbLOG.Text = "Se modifico el jabon en la base de datos.";

        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Esta seguro que quiere eliminar el usuario?", "ELIMINAR USER", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (a == DialogResult.Yes)
            {
                Asignar(Int32.Parse(tbCodigo.Text));
                nJabones = new BE.NJabones();
                nJabones.Delete(Bjabones);
                CargarGrilla();
                lbLOG.ForeColor = Color.Red;
                lbLOG.Text = "Se elimino el jabon de la base de datos.";
            }
            else
            {
                lbLOG.ForeColor = Color.Cyan;
                lbLOG.Text = "No se elimino el jabon";
            }
        }
        #endregion

        #region Metodos mios
        protected void Asignar()
        {
            Bjabones = new BE.Jabones
            {
                Id = Int32.Parse(tbCodigo.Text),
                Color = cbColor.Text,
                Aroma = cbAroma.Text,
                Base = cbBase.Text,
                Cantidad = Int32.Parse(tbCantidad.Text)
            };
        }
        protected void Asignar(int Id)
        {
            Bjabones = new BE.Jabones
            {
                Id = Id
            };
        }

        //Esta poronga no me esta mostrando en el DGV los datos.
        void CargarGrilla()
        {
            BE.NJabones Jabon = new BE.NJabones();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Jabon.CargarJabones();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Coral;
        }
        #endregion
    }
}
