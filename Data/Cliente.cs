using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Cliente
    {
      public Int16? Id { get; set; }
      public string Identificacion { get; set; }
        public TipoIdentificacion TipoIdn { get; set; } = new TipoIdentificacion();
      public Int16? TipoIdnId { get; set; }
      public string NombreCompleto {get;set;}
      public string Celular {get;set;}
      public string Email {get;set;}
      public string RutaFoto {get;set;}
      public DateTime? FechaCreacion {get;set;}
      public DateTime? FechaModificacion {get;set;}
      public Int16? UsrIdCreo {get;set;}
    }
}
