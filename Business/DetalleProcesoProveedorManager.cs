using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DetalleProcesoProveedorManager : DetalleProcesoProveedorData
    {
        public DetalleProcesoProveedorManager(string constring) : base(constring)
        {
        }
        public List<DetalleProcesoProveedor> ObtenerDetalleProcesoProveedor(DetalleProcesoProveedor detalleProcesoProveedor)
        {
            return GetDetalleProcesoProveedor(detalleProcesoProveedor);
        }
        public int InserartDetalleProcesoProveedor(DetalleProcesoProveedor detalleProcesoProveedor)
        {
            return InsertDetalleProcesoProveedor(detalleProcesoProveedor);
        }
    }
}
