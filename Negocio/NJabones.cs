using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using Negocio;
using Mapper;

namespace Negocio
{
    public class NJabones
    {
        public List<Negocio.Jabones> CargarJabones()
        {
            var mj = new MJabones();
            return mj.CargarJabones();
        }

        public List<string> SelectAROMAS()
        {
            var mj = new MJabones();
            return mj.SelectAROMAS();
        }

        public List<string> SelectBASES()
        {
            var mj = new MJabones();
            return mj.SelectBASES();
        }

        public List<string> SelectCOLORES()
        {
            var mj = new MJabones();
            return mj.SelectCOLORES();
        }

        public bool Insert(Negocio.Jabones u)
        {
            var mj = new MJabones();
            return mj.Insert(u);
        }

        public bool Update(Negocio.Jabones u)
        {
            var mj = new MJabones();
            return mj.Update(u);
        }

        public bool Delete(Negocio.Jabones u)
        {
            var mj = new MJabones();
            return mj.Delete(u);
        }
    }
}
