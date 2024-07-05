using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TipoProcesoProveedorManager:TipoProcesoProveedorData
    {
        public TipoProcesoProveedorManager(string constring):base(constring)
        { 
        }
        public List<TipoProcesoProveedor> ObtenerTipoProcesoProveedor(TipoProcesoProveedor tipoProcesoProveedor)
        {
            return GetTipoProcesoProveedor(tipoProcesoProveedor);
        }
    }
}
