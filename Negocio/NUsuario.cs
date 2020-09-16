using BE;
using DAL;
using Mapper;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Data;

namespace BE
{
    public class NUsuario
    {
        public List<BE.Usuarios> LoadUsers()
        {
            var mj = new MUsers();
            return mj.LoadUsers();
        }

        public bool Insert(Usuarios u)
        {
            var mj = new MUsers();
            return mj.Insert(u);
        }

        public bool Update(Usuarios u)
        {
            var mj = new MUsers();
            return mj.Update(u);
        }

        public bool Delete(Usuarios u)
        {
            var mj = new MUsers();
            return mj.Delete(u);
        }
    }
}
