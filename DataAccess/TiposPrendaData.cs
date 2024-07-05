using Dapper;
using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TiposPrendaData
    {
        public string? constring { get; set; }
        public TiposPrendaData(string constring)
        {
            this.constring = constring;
        }
        public List<TiposPrenda> GetTiposPrenda(TiposPrenda tiposPrenda)
        {
            string procedure = "GetTiposPrenda";
            var parametros = new {TpsPrnId= tiposPrenda.Id, TpsPrnDescripcion=tiposPrenda.Descripcion, TpsPrnDiasEntrega=tiposPrenda.DiasEntrega}; 
            List<TiposPrenda> listaTiposPrenda = new List<TiposPrenda>();
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                var Result=conexion.Query(procedure,parametros,commandType:System.Data.CommandType.StoredProcedure).ToList();
                foreach (var item in Result)
                {
                    TiposPrenda Data = new TiposPrenda();
                    Data.Id = item.TpsPrnId;
                    Data.Descripcion=item.TpsPrnDescripcion;
                    Data.DiasEntrega=item.TpsPrnDiasEntrega;
                    listaTiposPrenda.Add(Data);
                }
            }
            catch (Exception e)
            {
                listaTiposPrenda = new List<TiposPrenda>();
                throw e;
            }
            return listaTiposPrenda;
        }

    }
}
