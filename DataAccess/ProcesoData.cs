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
    public class ProcesoData
    {
        public string? constring { get; set; }
        public ProcesoData(string constring) 
        {
            this.constring = constring;
        }
        public List<Proceso> GetProceso(Proceso proceso)
        {
            string procedure = "GetProceso";
            var parametros = new { PrcId = proceso.Id, PrcDescripcion = proceso.Descripcion };
            List<Proceso> listaProceso = new List<Proceso>();
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                
                var Restult=conexion.Query(procedure, parametros, commandType: System.Data.CommandType.StoredProcedure).ToList();
                foreach (var item in Restult)
                {
                    Proceso Data = new Proceso();
                    Data.Id = item.PrcId;
                    Data.Descripcion = item.PrcDescripcion;
                    listaProceso.Add(Data);
                }
            }
            catch (Exception ex)
            {
                listaProceso = new List<Proceso>();
                throw;
            }
            return listaProceso;
        }
    }
}
