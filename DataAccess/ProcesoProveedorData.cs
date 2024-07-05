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
    public class ProcesoProveedorData
    {
        public string? constring { get; set; }
        public ProcesoProveedorData(string constring)
        {
            this.constring = constring;
        }
        public List<ProcesoProveedor> GetProcesoProveedor(ProcesoProveedor procesoProveedor)
        {
            DetalleProcesoProveedorData detalleData = new DetalleProcesoProveedorData(constring);
            List<ProcesoProveedor> listaProceso = new List<ProcesoProveedor>();
            SqlConnection conexion = new SqlConnection(constring);
            string procedure = "GetProcesoProveedor";
            var parametros = new { PrcPrvId = procesoProveedor.Id, PrcPrvFechaFacturacion = procesoProveedor.FechaFacturacion, PrcPrvPrecioTotal = procesoProveedor.PrecioTotal, PrcPrvUsrIdCreo = procesoProveedor.UsrIdCreo };
            try
            {
                var Result = conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure);
                foreach (var item in Result)
                {
                    ProcesoProveedor Data = new ProcesoProveedor();
                    Data.Id = item.PrcPrvId;
                    Data.FechaFacturacion = item.PrcPrvFechaFacturacion;
                    Data.PrecioTotal = item.PrcPrvPrecioTotal;
                    Data.UsrIdCreo = item.PrcPrvUsrIdCreo;
                    Data.detalles = detalleData.GetDetalleProcesoProveedor(new DetalleProcesoProveedor() { ProcesoProveedorId = item.PrcPrvId });
                    listaProceso.Add(Data);
                }
            }
            catch (Exception)
            {
                listaProceso = new List<ProcesoProveedor>();
                throw;
            }
            return listaProceso;
        }
        public int InsertProcesoProveedor(ProcesoProveedor procesoProveedor)
        {
            int resultado = 0;
            string procedure = "InsertProcesoProveedor";
            var parametros = new { PrcPrvFechaFacturacion = procesoProveedor.FechaFacturacion, PrcPrvPrecioTotal = procesoProveedor.PrecioTotal, PrcPrvUsrIdCreo = procesoProveedor.UsrIdCreo };
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                var Result = conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
                resultado = Result.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }
    }
}
