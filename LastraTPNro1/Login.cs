using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using Negocio;

namespace LastraTPNro1
{
    public partial class Form_Login : Form
    {
        //La capa de Interfaz o UI tiene como referencias:
        //BE
        //Negocio

        #region Variables publicas
        
        public bool LoginOK = false;
        protected string user;
        protected string pass;

        #endregion
        
        public Form_Login()
        {
            InitializeComponent();

            //Hacer foco en el user
            tbUser.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //El close cierra el form actual, el App.exit cierra la aplicacion.
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Registro

        }

        #region Login
        private void button2_Click(object sender, EventArgs e)
        {

            //Logueo
            TestConnection tc = new TestConnection();

            //Pregunto a la bd si existe ese usuario que estoy buscando
             user = tc.Test2();
             pass = tc.Test2("Password");

            //If existe uso el If que valida User y Pw

            //Si no existe, va el else 

            if (tbUser.Text == user && tbPass.Text == pass)
            {
                LoginOK = true;
            }
            else
            {
                MessageBox.Show("No se pudo iniciar sesion con ese usuario", "Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
                lbLOG.ForeColor = Color.Red;
                lbLOG.Text = "Flasheaste amigo";
            }

            if (LoginOK == true)
            {
                Gestion g = new Gestion();
                g.Show();
                this.Hide();
            }

        }
        #endregion
    }
}
