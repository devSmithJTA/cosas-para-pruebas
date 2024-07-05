using Dapper;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClienteData
    {
        public string? constring { get; set; }
        public ClienteData(string? constring)
        {
            this.constring = constring;
        }
        public int InsertCliente(Cliente cliente)
        {
            int resultado;
            string procedure = "InsertCliente";
            try
            {
                var parametro = new { ClnTpoIdnId=cliente.TipoIdnId, ClnIdentificacion=cliente.Identificacion, ClnNombreCompleto = cliente.NombreCompleto, ClnCelular = cliente.Celular, ClnRutaFoto = cliente.RutaFoto, ClnFechaCreacion = DateTime.Now, ClnFechaModificacion = DateTime.Now, ClnUsrIdCreo = cliente.UsrIdCreo, ClnEmail= cliente.Email};
                SqlConnection connection = new SqlConnection(constring);
                var Result = connection.Query<string>(procedure, parametro, commandType: CommandType.StoredProcedure).FirstOrDefault();
                resultado = Convert.ToInt32(Result);
            }
            catch (Exception e)
            {
                throw e;
            }
            return resultado;
        }
        public void UpdateCliente(Cliente cliente)
        {
            int resultado;
            string procedure = "UpdateCliente";
            try
            {
                var parametro = new { ClnId=cliente.Id, ClnNombreCompleto = cliente.NombreCompleto,ClnRutaFoto=cliente.RutaFoto, ClnCelular = cliente.Celular, ClnFechaModificacion = DateTime.Now, ClnUsrIdCreo = cliente.UsrIdCreo, ClnEmail= cliente.Email};
                SqlConnection connection = new SqlConnection(constring);
                connection.Query<string>(procedure, parametro, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Cliente> GetCliente(Cliente cliente)
        {
            List<Cliente> ListaCliente = new List<Cliente>();
            string procedure = "GetCliente";
            var parametros = new { ClnId = cliente.Id, ClnTpoIdnId=cliente.TipoIdnId, ClnIdentificacion=cliente.Identificacion, ClnNombreCompleto = cliente.NombreCompleto, ClnCelular = cliente.Celular, ClnRutaFoto = cliente.RutaFoto, ClnFechaCreacion = cliente.FechaCreacion, ClnFechaModificacion = cliente.FechaModificacion, ClnUsrIdCreo = cliente.UsrIdCreo,ClnEmail=cliente.Email };
            try
            {
                SqlConnection conexion = new SqlConnection(constring);
                var Result = conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure);
                foreach (var item in Result)
                {
                    Cliente Data = new Cliente();
                    Data.Id = item.ClnId;
                    Data.TipoIdnId=item.ClnTpoIdnId;
                    Data.TipoIdn.Id=item.ClnTpoIdnId;
                    Data.TipoIdn.Descripcion= item.TpoIdnDescripcion;
                    Data.Identificacion=item.ClnIdentificacion;
                    Data.NombreCompleto = item.ClnNombreCompleto;
                    Data.Celular = item.ClnCelular;
                    Data.RutaFoto = item.ClnRutaFoto;
                    Data.FechaCreacion = item.ClnFechaCreacion;
                    Data.FechaModificacion = item.ClnFechaModificacion;
                    Data.UsrIdCreo = item.ClnUsrIdCreo;
                    Data.Email = item.ClnEmail;
                    ListaCliente.Add(Data);
                }
            }
            catch (Exception)
            {
                ListaCliente = new List<Cliente>();
                throw;
            }
            return ListaCliente;
        }
        public int CountCliente() 
        {
            SqlConnection conexion = new SqlConnection(constring);
            int ConteoCliente = 0;
            string procedure = "GetMaxCliente";
            try
            {
                var Result= conexion.Query(procedure,commandType:CommandType.StoredProcedure).FirstOrDefault();
                ConteoCliente=Result.MaxId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ConteoCliente;
        }
    }
}
