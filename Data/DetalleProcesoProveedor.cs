using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DetalleProcesoProveedor
    {
      public int? Id {get;set;}
      public int? ProcesoProveedorId {get;set;}
      public TipoProcesoProveedor tipoProceso { get; set; } = new TipoProcesoProveedor();
      public Int16? TipoProcesoProveedorId {get;set;}
      public Int16? Cantidad {get;set;}
      public Decimal? Precio {get;set;}
      public DateTime? FechaCreacion {get;set;}
      public Int16? UsrIdCreo { get; set; }
    }
}
