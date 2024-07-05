using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TelasManager : TelasData
    {
        public TelasManager(string constring):base(constring) 
        {}
        public List<Telas> GetListaTelas(Telas telas)
        {
            List<Telas> listTelas = new List<Telas>();
            listTelas=GetTelas(telas);
            return listTelas;
        }
    }
}
