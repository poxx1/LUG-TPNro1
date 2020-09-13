using System;
using System.Windows.Forms;
using Negocio;
using BE;

namespace LastraTPNro1
{
    public partial class Gestion : Form
    {
        public Gestion()
        {
            InitializeComponent();
            MessageBox.Show("Bienvenido", "Tango Software",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

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
            MessageBox.Show(test.Test());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region MetodosInutiles
        private void button2_Click(object sender, EventArgs e)
        {
            TestConnection test = new TestConnection();
            MessageBox.Show(test.Test());
        }
        #endregion

    }
}
