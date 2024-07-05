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
    public class DetalleProcesoProveedorData
    {
        public string? constring { get; set; }
        public DetalleProcesoProveedorData(string constring)
        {
            this.constring = constring;
        }
        public List<DetalleProcesoProveedor> GetDetalleProcesoProveedor(DetalleProcesoProveedor detalle)
        {
            string procedure = "GetDetalleProcesoProveedor";
            SqlConnection connection = new SqlConnection(constring);
            var parametros = new { DtlPrcPrvId = detalle.Id, DtlPrcPrvPrcPrvId = detalle.ProcesoProveedorId, DtlPrcPrvTpPrcPrvId = detalle.TipoProcesoProveedorId, DtlPrcPrvCantidad = detalle.Cantidad, DtlPrcPrvPrecio = detalle.Precio, DtlPrcPrvFechaCreacion = detalle.FechaCreacion, DtlPrcPrvUsrIdCreo = detalle.UsrIdCreo };
            List<DetalleProcesoProveedor> listDetalle = new List<DetalleProcesoProveedor>();
            try
            {
                var Result = connection.Query(procedure, parametros, commandType: CommandType.StoredProcedure).ToList();
                foreach (var item in Result)
                {
                    DetalleProcesoProveedor Data = new DetalleProcesoProveedor();
                    Data.Id = item.DtlPrcPrvId;
                    Data.ProcesoProveedorId = item.DtlPrcPrvPrcPrvId;
                    Data.TipoProcesoProveedorId = item.DtlPrcPrvTpPrcPrvId;
                    Data.tipoProceso.Id = item.DtlPrcPrvTpPrcPrvId;
                    Data.tipoProceso.Descripcion = item.TpPrcPrvDescripcion;
                    Data.Cantidad = item.DtlPrcPrvCantidad;
                    Data.Precio = item.DtlPrcPrvPrecio;
                    Data.FechaCreacion = item.DtlPrcPrvFechaCreacion;
                    Data.UsrIdCreo = item.DtlPrcPrvUsrIdCreo;
                    listDetalle.Add(Data);
                }
            }
            catch (Exception e)
            {
                listDetalle = new List<DetalleProcesoProveedor>();
                throw e;
            }
            return listDetalle;
        }
        public int InsertDetalleProcesoProveedor(DetalleProcesoProveedor detalle)
        {
            int resultado = 0;
            SqlConnection conexion = new SqlConnection(constring);
            string procedure = "InsertDetalleProcesoProveedor";
            var parametros = new { DtlPrcPrvPrcPrvId = detalle.ProcesoProveedorId, DtlPrcPrvTpPrcPrvId = detalle.TipoProcesoProveedorId, DtlPrcPrvCantidad = detalle.Cantidad, DtlPrcPrvPrecio = detalle.Precio, DtlPrcPrvFechaCreacion = detalle.FechaCreacion, DtlPrcPrvUsrIdCreo = detalle.UsrIdCreo };
            try
            {
                var Result = conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
                resultado = Result.Id;
            }
            catch (Exception e)
            {

                throw e;
            }
            return resultado;
        }
        //public void UpdateDetalleProcesoProveedor(DetalleProcesoProveedor detalle)
        //{
        //    string procedure = "updateVentas";
        //    var parametros = new { DtlPrcPrvId=detalle.Id, DtlPrcPrvPrcPrvId = detalle.ProcesoProveedorId, DtlPrcPrvTpPrcPrvId = detalle.TipoProcesoProveedorId, DtlPrcPrvCantidad = detalle.Cantidad, DtlPrcPrvPrecio = detalle.Precio, DtlPrcPrvFechaCreacion = detalle.FechaCreacion, DtlPrcPrvUsrIdCreo = detalle.UsrIdCreo };
        //    try
        //    {
        //        SqlConnection conexion = new SqlConnection(constring);
        //        conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
