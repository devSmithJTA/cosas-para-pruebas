using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess
{
    public class TipoProcesoProveedorData
    {
        public string constring { get; set; }
        public TipoProcesoProveedorData(string constring)
        {
            this.constring = constring;
        }
        public List<TipoProcesoProveedor> GetTipoProcesoProveedor(TipoProcesoProveedor tipoProcesoProveedor)
        {
            string procedure = "GetTipoProcesoProveedor";
            var parametros = new { TpPrcPrvId = tipoProcesoProveedor.Id, TpPrcPrvDescripcion = tipoProcesoProveedor.Descripcion };
            List<TipoProcesoProveedor> listaTipoProcesoProveedor = new List<TipoProcesoProveedor>();
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                var Result = conexion.Query(procedure, parametros, commandType: System.Data.CommandType.StoredProcedure).ToList();
                foreach (var item in Result)
                {
                    TipoProcesoProveedor Data = new TipoProcesoProveedor();
                    Data.Id = item.TpPrcPrvId;
                    Data.Descripcion = item.TpPrcPrvDescripcion;
                    listaTipoProcesoProveedor.Add(Data);
                }

            }
            catch (Exception e)
            {
                listaTipoProcesoProveedor = new List<TipoProcesoProveedor>();
                throw;
            }
            return listaTipoProcesoProveedor;
        }

    }
}
