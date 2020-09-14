using System;
using System.Drawing;
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
            var NUser = new Negocio.NUsuario();
            var BUser = new BE.Usuarios();
            BUser.Us = tbUser.Text;
            BUser.Pw = tbPass.Text;
            NUser.Insert(BUser);

            lbLOG.ForeColor = Color.Green;
            lbLOG.Text = "Se agrego el jabon a la base de datos.";
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Esta seguro que quiere eliminar el usuario?", "ELIMINAR USER", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (a == DialogResult.Yes)
            {
                var NUser = new Negocio.NUsuario();
                var BUser = new BE.Usuarios();
                BUser.Us = tbUser.Text;
                NUser.Delete(BUser);

                lbLOG.ForeColor = Color.Red;
                lbLOG.Text = "Se elimino el usuario de la base de datos";
            }
            else
                lbLOG.Text = "No se elimino el usuario";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var NUser = new Negocio.NUsuario();
            var BUser = new BE.Usuarios();
            BUser.Us = tbUser.Text;
            BUser.Pw = tbPass.Text;
            NUser.Update(BUser);

            lbLOG.ForeColor = Color.Yellow;
            lbLOG.Text = "Se modifico el jabon en la base de datos.";
        }
    }
}
