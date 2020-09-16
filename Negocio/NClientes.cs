using System;
using System.Collections.Generic;
using DAL;
using BE;
using System.Data;
using Mapper;

namespace Negocio
{
    public class NClientes
    {
        public List<BE.Clientes> CargarCliente()
        {
            //instancio un objeto de la clase Mapper y esta interacture con la BD
            var mj = new MClientes();
            return mj.CargarClientes();
        }

        public List<string> SelectINSTAGRAM()
        {
            //instancio un objeto de la clase Mapper y esta interacture con la BD
            var mj = new MClientes();
            return mj.SelectINSTAGRAM();
        }

        public List<string> SelectLOCALIDAD()
        {
            //instancio un objeto de la clase Mapper y esta interacture con la BD
            var mj = new MClientes();
            return mj.SelectLOCALIDAD();
        }

        public List<string> SelectFACEBOOK()
        {
            //instancio un objeto de la clase Mapper y esta interacture con la BD
            var mj = new MClientes();
            return mj.SelectFACEBOOK();
        }

        public bool InsertCliente(BE.Clientes j)
        {
            //instancio un objeto de la clase Mapper y esta interacture con la BD
            var mj = new MClientes();
            return mj.InsertCliente(j);
        }

        public bool UpdateCliente(BE.Clientes j)
        {
            //instancio un objeto de la clase Mapper y esta interacture con la BD
            var mj = new MClientes();
            return mj.UpdateCliente(j);
        }

        public bool DeleteCliente(BE.Clientes j)
        {
            //instancio un objeto de la clase Mapper y esta interacture con la BD
            var mj = new MClientes();
            return mj.DeleteCliente(j);
        }
    }
}
