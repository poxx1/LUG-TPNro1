using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using BE;
using Mapper;

namespace BE
{
    public class NJabones
    {
        public List<BE.Jabones> CargarJabones()
        {
            var mj = new MJabones();
            return mj.CargarJabones();
        }

        public bool Insert(BE.Jabones u)
        {
            var mj = new MJabones();
            return mj.Insert(u);
        }

        public bool Update(BE.Jabones u)
        {
            var mj = new MJabones();
            return mj.Update(u);
        }

        public bool Delete(BE.Jabones u)
        {
            var mj = new MJabones();
            return mj.Delete(u);
        }
    }
}

