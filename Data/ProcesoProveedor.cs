using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProcesoProveedor
    {
      public int? Id {get;set;}
      public DateTime? FechaFacturacion {get;set;}
      public Decimal? PrecioTotal {get;set;}
      public Int16? UsrIdCreo { get; set; }
        public List<DetalleProcesoProveedor> detalles { get; set; }
    }
}
