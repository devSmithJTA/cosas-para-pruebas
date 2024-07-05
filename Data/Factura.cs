using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Factura
    {
      public int? Id {get;set;}
      public Int16? ClnId {get;set;}
      public Cliente cliente {get;set;}
      public Decimal? PrecioTotal {get;set;}
      public Int16? DiasEntrega {get;set;}
      public DateTime? FechaCreacion {get;set;}
      public Int16? UsrIdCreo { get; set; }
      public List <Ventas> venta { get; set; }
    }
}
