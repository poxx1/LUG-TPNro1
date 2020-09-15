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
            int counter=1;

            string query = "SELECT Clientes.Nombre,Clientes.Apellido,Clientes.Direccion,Clientes.Telefono,"+
               "Clientes.Instagram,Clientes.Facebook,Localidad.Nombre_Localidad as Localidad"+
               " FROM Clientes, Localidad WHERE Clientes.Localidad = Localidad.ID_Localidad; ";

            Ds = d.ReadDS(query);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    var BCliente = new Clientes();
                    var NClientes = new NClientes();
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

        public bool InsertCliente(BE.Clientes c)
        {
            var a = new Accesos();
            string query = "INSERT into Clientes (ID_Cliente, Nombre, Apellido,Direccion,Telefono,Instagram,Facebook,Localidad)" +
                "VALUES ('"+c.ID_Cliente+"','"+c.Nombre+"','"+c.Apellido+"','"+c.Direccion+"','"+c.Telefono+"','"+c.Instagram+"','"+c.Facebook+"','"+c.Localidad+"')";      
            return a.Write(query);
        }

        public bool UpdateCliente(BE.Clientes c)
        {
            var a = new Accesos();
            string query = "UPDATE Clientes SET Nombre = '"+c.Nombre+"', Apellido = '"+c.Apellido+"', Direccion = '"+c.Direccion+"'," +
                "Telefono = '"+c.Telefono+"', Instagram = '"+c.Instagram+"', Facebook = '"+c.Facebook+"', Localidad = '"+c.Localidad+"' "+
                "WHERE ID_Cliente = '"+c.ID_Cliente+"'";
            return a.Write(query);
        }

        public bool DeleteCliente(BE.Clientes cliente)
        {
            var a = new Accesos();
            string query = "DELETE from Clientes WHERE ID_Cliente = "+cliente.ID_Cliente+"";
            return a.Write(query);
        }
    }
}
