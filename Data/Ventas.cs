using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ventas
    {
        public int? Id { get; set; }
        public bool? Estado { get; set; }
        public int? FacturaId { get; set; }
        public Int16?  ProcesoId { get; set; }
        public Proceso proceso { get; set; } = new Proceso();
        public Int16?  TiposPrendaId { get; set; }
        public TiposPrenda tiposPrenda { get; set; } = new TiposPrenda();
        public Int16?  TelasId { get; set; }
        public Telas telas { get; set; } = new Telas();
        public string  Color { get; set; }
        public Int16?  AdicionId { get; set; }
        public Adiciones adicion { get; set; } = new Adiciones();
        public byte?  Cantidad { get; set; }
        public string  Observacion { get; set; }
        public decimal?  Precio { get; set; }
        public DateTime?  FechaCreacion { get; set; }
        public DateTime?  FechaModificacion { get; set; }
        public Int16?  UsuarioIdCreo { get; set; }
    }
}
