using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProcesoProveedorManager:ProcesoProveedorData
    {
        public ProcesoProveedorManager(string constring) : base(constring)
        {
        }
        public List<ProcesoProveedor> ObtenerProcesoProveedor(ProcesoProveedor procesoProveedor)
        {
            return GetProcesoProveedor(procesoProveedor);
        }
        public int InsertarProcesoProveedor(ProcesoProveedor procesoProveedor)
        {
            return InsertProcesoProveedor(procesoProveedor);
        }
    }
}
