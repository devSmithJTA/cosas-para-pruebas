using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AdicionesManager : AdicionesData
    {
        public AdicionesManager(string constring) :base(constring)
        {
        }
        public List<Adiciones> GetListaAdiciones(Adiciones adiciones)
        {
            List<Adiciones> listAdiciones = new List<Adiciones>();
            listAdiciones = GetAdiciones(adiciones);
            return listAdiciones;
        }
    }
}
