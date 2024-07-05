using Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AdicionesData
    {
        public string? constring { get; set; }
        public AdicionesData(string constring)
        {
            this.constring = constring;
        }
        public List<Adiciones> GetAdiciones(Adiciones adiciones)
        {
            var connection = new SqlConnection(constring);
            List<Adiciones> DataList = new List<Adiciones>();
            try
            {
                var parametro = new { AdcId=adiciones.Id, AdcDescripcion=adiciones.Descripcion };
                var procedure = "[GetAdiciones]";
                var Result = connection.Query(procedure,parametro,commandType: CommandType.StoredProcedure).ToList();
                foreach (var item in Result)
                {
                    Adiciones Data = new Adiciones();
                    Data.Id = item.AdcId;
                    Data.Descripcion = item.AdcDescripcion;
                    DataList.Add(Data);
                }
            }
            catch (Exception)
            {
                DataList = new List<Adiciones>();
            }
            return DataList;
        }
    }
}
