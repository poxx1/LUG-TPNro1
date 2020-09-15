using System;
using Negocio;
using BE;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace LastraTPNro1
{
    public partial class FClientes : Form
    {
        #region Variables
        NClientes Nclientes;
        NLocalidad NLocalidad;
        BE.Clientes BCliente;
        BE.Localidades BLocalidad;

        //Este vector lo creo para despues splitear
        string[] s = new string[2];
        #endregion

        #region Metodos de los controles

        public FClientes()
        {
            InitializeComponent();
            LoadLocs();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            string id = tbIDC.Text;
            SetCliente(id);
            Nclientes = new NClientes();
            Nclientes.DeleteCliente(BCliente);
            lbLOG.ForeColor = Color.Red;
            lbLOG.Text = "Se elimino el cliente de la base de datos.";
        }

        private void btInsertLOC_Click(object sender, EventArgs e)
        {
            try
            {
                SetLocalidad();
                NLocalidad = new NLocalidad();
                NLocalidad.Insert(BLocalidad);
                lbLOG.ForeColor = Color.Green;
                lbLOG.Text = "Se agrego la localidad a la base de datos.";
                LoadLocs();
            }
            catch (Exception w)
            {
                throw w;
            }
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            //Return home
            Hide();
            Gestion gestion = new Gestion();
            gestion.Show();
        }
        
        private void btInsert_Click(object sender, EventArgs e)
        {

            lbLOG.ForeColor = Color.Green;
            lbLOG.Text = "Se agrego el jabon a la base de datos.";

        }

        private void btUpdateLOC_Click(object sender, EventArgs e)
        {
            try
            {
                SetLocalidad();
                NLocalidad = new NLocalidad();
                NLocalidad.Update(BLocalidad);
                lbLOG.ForeColor = Color.Yellow;
                lbLOG.Text = "Se modifico la localidad en la base de datos.";
                LoadLocs();
            }
            catch (Exception w)
            {
                throw w;
            }
        }

        private void btDeleteLoc_Click(object sender, EventArgs e)
        {
            try
            {
                SetLocalidad();
                NLocalidad = new NLocalidad();
                NLocalidad.Delete(BLocalidad);
                lbLOG.ForeColor = Color.Red;
                lbLOG.Text = "Se elimino la localidad de la base de datos.";
                LoadLocs();
            }
            catch (Exception w)
            {
                throw w;
            }
        }

        private void cbASD_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbLOG.Text = "Se agrego a los campos la localidad elegida";
            string a = cbASD.Text;
            s = a.Split('.');
            tbIDLoc.Text = s[0];
            tbLocName.Text = s[1];
            tbLocCliente.Text = s[1];
        }

        private void FClientes_Load(object sender, EventArgs e)
        {

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Metodos creados
        private void SetCliente()
        {
            BCliente = new Clientes();
            BCliente.ID_Cliente = Int32.Parse(tbIDC.Text);
            BCliente.Nombre = tbNombreC.Text;
            BCliente.Apellido = tbApellidoC.Text;
            BCliente.Direccion = tbDirC.Text;
            BCliente.Localidad = tbLocCliente.Text;
            BCliente.Instagram = tbIGC.Text;
            BCliente.Facebook = tbFBC.Text;
        }

        private void SetCliente(string id)
        {
            //Los demas me importan un carajo porque esto es solo para eliminar el cliente
            BCliente = new Clientes();
            BCliente.ID_Cliente = Int32.Parse(id);
        }

        private void SetLocalidad()
        {
            BLocalidad = new Localidades();
            if (tbIDLoc.Text != "")
                BLocalidad.ID_Localidad = Int32.Parse(tbIDLoc.Text);

            BLocalidad.Nombre_Localidad = tbLocName.Text;
        }

        private void LoadLocs()
        {
            NLocalidad = new NLocalidad();
            var l = new List<BE.Localidades>();
            l = NLocalidad.LoadLocalidades();
            foreach (var item in l)
            {
                cbASD.Items.Add(item.ToString());
            }
        }

        private void LoadClientes()
        {

        }
        #endregion
    }
}
