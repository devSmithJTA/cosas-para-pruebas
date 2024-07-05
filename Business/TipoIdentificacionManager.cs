using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TipoIdentificacionManager: TipoIdentificacionData
    {
        public TipoIdentificacionManager(string constring):base(constring)
        {
        }
        public List<TipoIdentificacion> ObtenerTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
        {
            return GetTipoIdentificacion(tipoIdentificacion);
        }
    }
}
