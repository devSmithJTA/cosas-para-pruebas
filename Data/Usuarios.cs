using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Usuarios
    {
      public Int16? Id {get;set;}
      public string Usuario {get;set;}
      public string Password {get;set;}
      public string Nombres {get;set;}
      public string Apellidos {get;set;}
      public Int16? TipoIdentificacion {get;set;}
      public string Identificacion {get;set;}
      public DateTime? FechaCreacion {get;set;}
      public Int16? UsuarioCreacion {get;set;}
      public DateTime? FechaModificacion {get;set;}
      public Int16? UsuarioModificacion {get;set;}
      public bool? Estado { get; set; }
    }
}
