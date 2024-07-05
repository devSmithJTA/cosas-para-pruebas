using Dapper;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TipoIdentificacionData
    {
        public string constring { get; set; }
        public TipoIdentificacionData(string constring) 
        {
            this.constring = constring;
        }
        public List<TipoIdentificacion> GetTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
        {
            List<TipoIdentificacion> listaTipo = new List<TipoIdentificacion>();
            SqlConnection conexion = new SqlConnection(constring);
            string procedure = "GetTipoIdentificacion";
            var parametros = new { TpoIdnId=tipoIdentificacion.Id, TpoIdnDescripcion=tipoIdentificacion.Descripcion };
            try
            {
                var Result=conexion.Query(procedure,parametros,commandType:CommandType.StoredProcedure);
                foreach (var item in Result)
                {
                    TipoIdentificacion Data = new TipoIdentificacion();
                    Data.Id = item.TpoIdnId;
                    Data.Descripcion=item.TpoIdnDescripcion;
                    listaTipo.Add(Data);
                }
            }
            catch (Exception)
            {
                listaTipo = new List<TipoIdentificacion>();
                throw;
            }
            return listaTipo;
        }
    }
}
