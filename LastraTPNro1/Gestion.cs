using System;
using System.Windows.Forms;
using BE;
using Mapper;

namespace LastraTPNro1
{
    public partial class Gestion : Form
    {
        public Gestion()
        {
            InitializeComponent();
            MessageBox.Show("Bienvenido", "Tango Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Metodos del formulario

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Menu para gestionar usuarios
            Usuarios usr = new Usuarios();
            usr.Show();
            Hide();
        }

        private void jabonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jabones jb = new Jabones();
            jb.Show();
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TestConnection test = new TestConnection();
            MessageBox.Show(test.Test(),"TEST DE CONEXION",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fc = new FClientes();
            fc.Show();
            Hide();
        }

        private void btInformesCT_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();

            var j = new MClientes();
            var t = j.SelectINSTAGRAM();
            foreach (var l in t)
            {
                listBox5.Items.Add(l.ToString());
            }
            t = j.SelectFACEBOOK();
            foreach (var l in t)
            {
                listBox6.Items.Add(l.ToString());
            }
            t = j.SelectLOCALIDAD();
            foreach (var l in t)
            {
                listBox1.Items.Add(l.ToString());
            }
        }

        private void btInformesJB_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            var j = new MJabones();
            var t = j.SelectAROMAS();
            foreach (var l in t)
            {
                listBox2.Items.Add(l.ToString());
            }
            t = j.SelectBASES();
            foreach (var l in t)
            {
                listBox3.Items.Add(l.ToString());
            }
            t = j.SelectCOLORES();
            foreach (var l in t)
            {
                listBox4.Items.Add(l.ToString());
            }
        }

        #endregion

        #region MetodosInutiles
        private void button2_Click(object sender, EventArgs e)
        {
            TestConnection test = new TestConnection();
            MessageBox.Show(test.Test());
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

       
    }
}
