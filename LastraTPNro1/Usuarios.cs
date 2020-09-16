using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using Seguridad;

namespace LastraTPNro1
{
    public partial class Usuarios : Form
    {
        #region Variables 

        TestConnection tc = new TestConnection();
        Cripter c = new Cripter();
        protected string a;
        protected string b;
        protected string user;
        protected string pass;

        #endregion

        public Usuarios()
        {
            InitializeComponent();
            LoadUsers();
        }

        #region Metodos del Formulario

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestion gestion = new Gestion();
            gestion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Encriptar();

            var NUser = new BE.NUsuario();
            var BUser = new BE.Usuarios();
            BUser.Us = a;
            BUser.Pw = b;
            NUser.Insert(BUser);

            lbLOG.ForeColor = Color.Green;
            lbLOG.Text = "Se agrego el usuario a la base de datos.";

            LoadUsers();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            var h = MessageBox.Show("Esta seguro que quiere eliminar el usuario?", "ELIMINAR USER", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                Encriptar();

                var NUser = new NUsuario();
                var BUser = new BE.Usuarios();
                BUser.Us = a;
                NUser.Delete(BUser);

                lbLOG.ForeColor = Color.Red;
                lbLOG.Text = "Se elimino el usuario de la base de datos";
            }
            else
                lbLOG.Text = "No se elimino el usuario";

            LoadUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var NUser = new BE.NUsuario();
            var BUser = new BE.Usuarios();

            Encriptar();

            BUser.Us = a;
            BUser.Pw = b;

            NUser.Update(BUser);

            lbLOG.ForeColor = Color.Yellow;
            lbLOG.Text = "Se modifico el usuario en la base de datos.";

            LoadUsers();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbUser.Text = comboBox1.Text;
        }
        #endregion

        #region Metodos mios

        protected void Encriptar()
        {
            a = c.Encriptar(tbUser.Text);
            b = c.Encriptar(tbPass.Text);
        }

        //El desencriptar esta al pedo porque no me interesa hacerlo aca.
        //Lo dejo por si en el futuro lo tengo que usar

        protected void Desencriptar()
        {
            user = c.Desencriptar(user);
            pass = c.Desencriptar(pass);
        }

        protected void LoadUsers()
        {
            tbPass.Clear();
            comboBox1.Items.Clear();
            var u = new BE.NUsuario();
            var l = u.LoadUsers();
            foreach (var j in l)
            {
                comboBox1.Items.Add(j.Us);
            }
        }

        #endregion
    }
}
