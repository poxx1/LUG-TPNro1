using Negocio;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MClientes
    {
        public List<Negocio.Clientes> CargarClientes()
        {
            var Ds = new DataSet();
            var d = new Accesos();
            var ListaClientes = new List<Clientes>();
            int counter = 1;

            string query = "SELECT Clientes.Nombre,Clientes.Apellido,Clientes.Direccion,Clientes.Telefono," +
               "Clientes.Instagram,Clientes.Facebook,Localidad.Nombre_Localidad as Localidad" +
               " FROM Clientes, Localidad WHERE Clientes.Localidad = Localidad.ID_Localidad; ";

            Ds = d.ReadDS(query);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    var BCliente = new Clientes();
                    var BLocalidad = new Localidades();

                    BCliente.ID_Cliente = counter;
                    BCliente.Nombre = fila[0].ToString();
                    BCliente.Apellido = fila[1].ToString();
                    BCliente.Direccion = fila[2].ToString();
                    BCliente.Telefono = fila[3].ToString();
                    BCliente.Instagram = fila[4].ToString();
                    BCliente.Facebook = fila[5].ToString();
                    BCliente.Localidad = fila[6].ToString();

                    ListaClientes.Add(BCliente);

                    counter++;
                }
            }

            else
                ListaClientes = null;

            return ListaClientes;
        }

        public bool InsertCliente(Negocio.Clientes c)
        {
            var a = new Accesos();
            string query = "INSERT into Clientes (ID_Cliente, Nombre, Apellido,Direccion,Telefono,Instagram,Facebook,Localidad)" +
                "VALUES ('" + c.ID_Cliente + "','" + c.Nombre + "','" + c.Apellido + "','" + c.Direccion + "','" + c.Telefono + "','" + c.Instagram + "','" + c.Facebook + "','" + c.Localidad + "')";
            return a.Write(query);
        }

        public bool UpdateCliente(Negocio.Clientes c)
        {
            var a = new Accesos();
            string query = "UPDATE Clientes SET Nombre = '" + c.Nombre + "', Apellido = '" + c.Apellido + "', Direccion = '" + c.Direccion + "'," +
                "Telefono = '" + c.Telefono + "', Instagram = '" + c.Instagram + "', Facebook = '" + c.Facebook + "', Localidad = '" + c.Localidad + "' " +
                "WHERE ID_Cliente = '" + c.ID_Cliente + "'";
            return a.Write(query);
        }

        public bool DeleteCliente(Negocio.Clientes cliente)
        {
            var a = new Accesos();
            string query = "DELETE from Clientes WHERE ID_Cliente = " + cliente.ID_Cliente + "";
            return a.Write(query);
        }

        #region Metodos de los informes

        public List<string> SelectLOCALIDAD()
        {
            DataSet ds = new DataSet();
            Accesos datos = new Accesos();
            var Localidad = "";
            var Cantidad = 0;

            string query = "SELECT Localidad.Nombre_Localidad,COUNT(Localidad) as 'Cantidad' FROM Localidad,Clientes" +
            " WHERE Localidad.ID_Localidad = Clientes.Localidad GROUP BY Localidad.Nombre_Localidad";

            ds = datos.ReadDS(query);

            var listaJabones = new List<string>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Localidad = fila[0].ToString();

                    Cantidad = Convert.ToInt32(fila[1]);

                    listaJabones.Add(Localidad + ": " + Cantidad.ToString());
                }
            }
            else
            {
                listaJabones = null;
            }
            return listaJabones;
        }

        public List<string> SelectINSTAGRAM()
        {
            DataSet ds = new DataSet();
            Accesos datos = new Accesos();
            var Cantidad = "";

            string query = "SELECT COUNT(Instagram) as 'Cantidad' FROM Clientes WHERE Instagram != ' '";

            ds = datos.ReadDS(query);

            var listaJabones = new List<string>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Cantidad = fila[0].ToString();

                    listaJabones.Add("Cantidad: " + Cantidad);
                }
            }
            else
            {
                listaJabones = null;
            }
            return listaJabones;
        }

        public List<string> SelectFACEBOOK()
        {
            DataSet ds = new DataSet();
            Accesos datos = new Accesos();
            var Cantidad = "";

            string query = "SELECT COUNT(Facebook) as 'Cantidad' FROM Clientes WHERE Facebook != ' '";

            ds = datos.ReadDS(query);

            var listaJabones = new List<string>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Cantidad = fila[0].ToString();

                    listaJabones.Add("Cantidad: " + Cantidad);
                }
            }
            else
            {
                listaJabones = null;
            }
            return listaJabones;
        }

        #endregion
    }
}
