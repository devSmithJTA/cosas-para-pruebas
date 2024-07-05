using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TiposPrendaManager :TiposPrendaData
    {
        public TiposPrendaManager(string constring) : base(constring) { }
        public List<TiposPrenda> GetListaTiposPrendas(TiposPrenda tiposPrenda)
        {
            List<TiposPrenda> listaTiposPrendas = new List<TiposPrenda>();
            listaTiposPrendas = GetTiposPrenda(tiposPrenda);
            return listaTiposPrendas;
        }

    }
}
