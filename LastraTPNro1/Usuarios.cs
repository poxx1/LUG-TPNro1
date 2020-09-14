using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastraTPNro1
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestion gestion = new Gestion();
            gestion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Esta seguro que quiere eliminar el usuario?", "ELIMINAR USER", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (a == DialogResult.Yes)
                lbLOG.Text = "Se elimino el usuario";
            else
                lbLOG.Text = "No se elimino el usuario";
        }
    }
}
