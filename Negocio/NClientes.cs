using System;
using System.Collections.Generic;
using DAL;
using BE;
using System.Data;

namespace Negocio
{
    public class NClientes
    {
        public List<BE.Clientes> CargarClientes()
        {
            var Ds = new DataSet();
            var d = new Accesos();
            var ListaClientes = new List<Clientes>();

            string query = "SELECT ";

            Ds = d.ReadDS(query);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    var BCliente = new Clientes();
                    var NClientes = new NClientes();
                    var BLocalidad = new Localidades();

                    BCliente.ID_Cliente = Convert.ToInt32(fila[0]);
                    BCliente.Nombre = fila[1].ToString();
                    BCliente.Apellido = fila[2].ToString();
                    BCliente.Direccion = fila[3].ToString();
                    BCliente.Telefono = fila[4].ToString();
                    BCliente.Instagram = fila[5].ToString();
                    BCliente.Facebook = fila[6].ToString();

                    BLocalidad.ID_Localidad = Convert.ToInt32(fila["ID_Localidad"]);
                    BLocalidad.Nombre_Localidad = fila["Localidad"].ToString();

                    BCliente.BLocalidad = BLocalidad;

                    ListaClientes.Add(BCliente);
                }
            }
            
            else
                ListaClientes = null;

            return ListaClientes;
        }

        public bool InsertCliente(BE.Clientes cliente)
        {
            var a = new Accesos();
            string query = "";
            return a.Escribir(query);
        }

        public bool UpdateCliente(BE.Clientes cliente)
        {
            var a = new Accesos();
            string query = "";
            return a.Escribir(query);
        }

        public bool DeleteCliente(BE.Clientes cliente)
        {
            var a = new Accesos();
            string query = "DELETE from Clientes WHERE ID_Cliente = "+cliente.ID_Cliente+"";
            return a.Escribir(query);
        }
    }
}
