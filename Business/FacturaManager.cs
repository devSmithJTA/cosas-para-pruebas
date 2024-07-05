using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FacturaManager:FacturaData
    {
        public FacturaManager(string constring):base(constring)
        {
        }
        public List<Factura> ListarFactura(Factura factura)
        {
            return GetListFactura(factura);
        }
        public int GuardarFactura(Factura factura)
        {
            return InsertFactura(factura);
        }
    }
}
