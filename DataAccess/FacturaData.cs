using Dapper;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FacturaData
    {
        public string constring = "";
        public FacturaData(string constring)
        {
            this.constring = constring;
        }
        public List<Factura> GetListFactura(Factura factura)
        {
            VentasData ventasData = new VentasData(constring);
            List<Factura> listFactura = new List<Factura>();
            string procedure = "GetFactura";
            var parametros = new { FctId = factura.Id, FctClnId = factura.ClnId, FctPrecioTotal = factura.PrecioTotal, FctFechaCreacion = factura.FechaCreacion, FctUsrIdCreo = factura.UsrIdCreo };
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                var Result = conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure);
                foreach (var item in Result)
                {
                    Factura Data = new Factura();
                    Cliente cliente = new Cliente();
                    Ventas ventas = new Ventas();
                    Data.Id = item.FctId;
                    Data.ClnId = item.FctClnId;
                    cliente.Id = item.FctClnId;
                    cliente.NombreCompleto = item.ClnNombreCompleto;
                    Data.cliente = cliente;
                    Data.FechaCreacion = item.FctFechaCreacion;
                    Data.PrecioTotal = item.FctPrecioTotal;
                    Data.DiasEntrega = item.FctDiasEntrega;
                    Data.UsrIdCreo = item.FctUsrIdCreo;
                    //ventas.FacturaId = item.FctId;
                    Data.venta=ventasData.GetVentas(new Ventas() {FacturaId= item.FctId });
                    listFactura.Add(Data);
                }
            }
            catch (Exception)
            {
                listFactura = new List<Factura>();
            }
            return listFactura;
        }
        public int InsertFactura(Factura factura)
        {
            int resultado = 0;
            string procedure = "InsertFactura";
            var parametros = new { FctClnId = factura.ClnId, FctPrecioTotal = factura.PrecioTotal, FctFechaCreacion = DateTime.Now, FctUsrIdCreo = factura.UsrIdCreo,FctDiasEntrega =factura.DiasEntrega};
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
