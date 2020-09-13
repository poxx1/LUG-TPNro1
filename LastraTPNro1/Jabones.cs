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
    public partial class Jabones : Form
    {
        public Jabones()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Gestion gestion = new Gestion();
            gestion.Show();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btModificar_Click(object sender, EventArgs e)
        {

        }

        private void btEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
