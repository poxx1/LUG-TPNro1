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
    public partial class Form_Login : Form
    {
        //La capa de Interfaz o UI tiene como referencias:
        //BE
        //Negocio

        #region Variables publicas
        
        public bool LoginOK = false;

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
            if (tbUser.Text == "poxi" && tbPass.Text == "1234")
            {
                LoginOK = true;
            }
            else
            {
                MessageBox.Show("No se pudo iniciar sesion con ese usuario", "Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
