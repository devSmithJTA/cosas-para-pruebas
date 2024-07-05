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
    public class VentasData
    {
        public string? constring { get; set; }
        public VentasData(string constring)
        {
            this.constring = constring;
        }
        public List<Ventas> GetVentas(Ventas ventas)
        {
            string procedure = "GetVentas";
            SqlConnection connection = new SqlConnection(constring);
            var parametro = new { VntId = ventas.Id, VntEstado = ventas.Estado, VntFctId = ventas.FacturaId, VntPrcId = ventas.ProcesoId, VntTpsPrnId = ventas.TiposPrendaId, VntTlsId = ventas.TelasId, VntColor = ventas.Color, VntAdcId = ventas.AdicionId, VntCantidad = ventas.Cantidad, VntObservacion = ventas.Observacion, VntPrecio = ventas.Precio, VntFechaCreacion = ventas.FechaCreacion, VntFechaModificacion = ventas.FechaModificacion, VntUsrIdCreo = ventas.UsuarioIdCreo };
            List<Ventas> listVentas = new List<Ventas>();
            try
            {
                var Result = connection.Query(procedure, parametro, commandType: CommandType.StoredProcedure).ToList();
                foreach (var item in Result)
                {
                    Ventas Data = new Ventas();
                    Data.Id = item.VntId;
                    Data.Estado = item.VntEstado;
                    Data.FacturaId = item.VntFctId;
                    Data.ProcesoId = item.VntPrcId;
                    Data.proceso.Id = item.VntPrcId;
                    Data.proceso.Descripcion = item.PrcDescripcion;
                    Data.TiposPrendaId = item.VntTpsPrnId;
                    Data.tiposPrenda.Id = item.VntTpsPrnId;
                    Data.tiposPrenda.Descripcion = item.TpsPrnDescripcion;
                    Data.TelasId = item.VntTlsId;
                    Data.telas.Id = item.VntTlsId;
                    Data.telas.Descripcion = item.TlsDescripcion;
                    Data.Color = item.VntColor;
                    Data.AdicionId = item.VntAdcId;
                    Data.adicion.Id = item.VntAdcId;
                    Data.adicion.Descripcion = item.AdcDescripcion;
                    Data.Cantidad = item.VntCantidad;
                    Data.Observacion = item.VntObservacion;
                    Data.Precio = item.VntPrecio;
                    Data.FechaCreacion = item.VntFechaCreacion;
                    Data.FechaModificacion = item.VntFechaModificacion;
                    Data.UsuarioIdCreo = item.VntUsrIdCreo;
                    listVentas.Add(Data);
                }
            }
            catch (Exception e)
            {
                listVentas = new List<Ventas>();
                throw e;
            }
            return listVentas;
        }
        public int InsertVenta(Ventas ventas)
        {
            int resultado = 0;
            SqlConnection conexion = new SqlConnection(constring);
            string procedure = "InsertVentas";
            var parametros = new { VntEstado = ventas.Estado, VntFctId = ventas.FacturaId, VntPrcId = ventas.ProcesoId, VntTpsPrnId = ventas.TiposPrendaId, VntTlsId = ventas.TelasId, VntColor = ventas.Color, VntAdcId = ventas.AdicionId, VntCantidad = ventas.Cantidad, VntObservacion = ventas.Observacion, VntPrecio = Convert.ToDecimal(ventas.Precio), VntFechaCreacion = ventas.FechaCreacion, VntFechaModificacion = ventas.FechaModificacion, VntUsrIdCreo = ventas.UsuarioIdCreo };
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
        public void DeleteVenta(Ventas ventas)
        {
            var parametros = new { VntId = ventas.Id };
            string procedure = "DeleteVentas";
            try
            {
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateVenta(Ventas ventas)
        {
            string procedure = "updateVentas";
            var parametros = new { VntId = ventas.Id, VntEstado = ventas.Estado, VntPrcId = ventas.ProcesoId, VntTpsPrnId = ventas.TiposPrendaId, VntTlsId = ventas.TelasId, VntColor = ventas.Color, VntAdcId = ventas.AdicionId, VntCantidad = ventas.Cantidad, VntObservacion = ventas.Observacion, VntPrecio = Convert.ToDecimal(ventas.Precio),  VntFechaModificacion = ventas.FechaModificacion};
            try
            {
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
