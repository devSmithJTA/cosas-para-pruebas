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
    public class TelasData
    {
        public string? constring { get; set; }
        public TelasData(string constring)
        {
            this.constring = constring;
        }
        public List<Telas> GetTelas(Telas telas)
        {
            string procedure = "GetTelas";
            var parametos = new {TlsId=telas.Id, TlsDescripcion=telas.Descripcion, TlsDiasEntrega=telas.DiasEntrega };
            List<Telas> listaTelas=new List<Telas>();
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                var Result=conexion.Query(procedure,parametos,commandType:System.Data.CommandType.StoredProcedure).ToList();
                foreach (var item in Result)
                {
                    Telas Data = new Telas();
                    Data.Id = item.TlsId;
                    Data.Descripcion = item.TlsDescripcion;
                    Data.DiasEntrega = item.TlsDiasEntrega;
                    listaTelas.Add(Data);
                }
            }
            catch (Exception e)
            {
                listaTelas = new List<Telas>();
                throw;
            }
            return listaTelas;
        }
    }
}
