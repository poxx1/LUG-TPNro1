using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using Seguridad;

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
            if (tbUser.Text == "" && tbPass.Text == "")
                lbLOG.Text = "NO SE INGRESO NINGUN DATO";
            else
            {
                //Encriptar lo que ingrese para ir a consultar a la bd
                Cripter c = new Cripter();
                string a;
                string b;
                a = c.Encriptar(tbUser.Text);
                b = c.Encriptar(tbPass.Text);

                //Logueo
                TestConnection tc = new TestConnection();

                //Pregunto a la bd si existe ese usuario encriptado que estoy buscando
                user = tc.SelectCript(a);
                pass = tc.SelectCript("Password", a);

                try
                {
                    //Desencripto para validar
                    user = c.Desencriptar(user);
                    pass = c.Desencriptar(pass);

                    if (tbUser.Text == user && tbPass.Text == pass)
                    {
                        LoginOK = true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo iniciar sesion con ese usuario", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                catch (Exception j)
                {
                    throw j;
                }
            }
        }
        #endregion

        private void btInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En caso de querer probar el programa utilizar las siguientes credenciales: "+Environment.NewLine+Environment.NewLine + "User: admin" +Environment.NewLine+"Pass: admin", "USUARIO PARA TESTING", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tbUser.Text = "admin";
            tbPass.Text = "admin";
        }
    }
}
