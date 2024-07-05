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
    public class UsuariosData
    {
        public string constring;
        public UsuariosData(string constring)
        {
            this.constring = constring;
        }
        public int InsertUsuarios(Usuarios usuarios)
        {
            int resultado = 0;
            string procedure = "InserUsuarios";
            var parametros = new { UsrUsuario = usuarios.Usuario, UsrPassword = usuarios.Password, UsrNombres = usuarios.Nombres, UsrApellidos = usuarios.Apellidos, UsrTipoIdentificacion = usuarios.TipoIdentificacion, UsrIdentificacion = usuarios.Identificacion, UsrFechaCreacion = usuarios.FechaCreacion, UsrUsuarioCreacion = usuarios.UsuarioCreacion, UsrFechaModificacion = usuarios.FechaModificacion, UsrUsuarioModificacion = usuarios.UsuarioModificacion, UsrEstado = usuarios.Estado };
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                var Result = conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
                resultado = Result.Id;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        public List<Usuarios> GetUsuarios(Usuarios usuarios)
        {
            List<Usuarios> listUsuarios = new List<Usuarios>();
            string procedure = "GetUsuarios";
            var parametros = new { UsrId = usuarios.Id, UsrUsuario = usuarios.Usuario, UsrPassword = "123", UsrNombres = usuarios.Nombres, UsrApellidos = usuarios.Apellidos, UsrTipoIdentificacion = usuarios.TipoIdentificacion, UsrIdentificacion = usuarios.Identificacion, UsrFechaCreacion = usuarios.FechaCreacion, UsrUsuarioCreacion = usuarios.UsuarioCreacion, UsrFechaModificacion = usuarios.FechaModificacion, UsrUsuarioModificacion = usuarios.UsuarioModificacion, UsrEstado = usuarios.Estado };
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                var Result = conexion.Query(procedure, parametros, commandType: CommandType.StoredProcedure);
                foreach (var item in Result)
                {
                    Usuarios Data = new Usuarios();
                    Data.Id = item.UsrId;
                    Data.Usuario = item.UsrUsuario;
                    Data.Password = item.UsrPassword;
                    Data.Nombres = item.UsrNombres;
                    Data.Apellidos = item.UsrApellidos;
                    Data.TipoIdentificacion = item.UsrTipoIdentificacion;
                    Data.Identificacion = item.UsrIdentificacion;
                    Data.FechaCreacion = item.UsrFechaCreacion;
                    Data.UsuarioCreacion = item.UsrUsuarioCreacion;
                    Data.FechaModificacion = item.UsrFechaModificacion;
                    Data.UsuarioModificacion = item.UsrUsuarioModificacion;
                    Data.Estado = item.UsrEstado;
                    listUsuarios.Add(Data);
                }
            }
            catch (Exception)
            {
                listUsuarios = new List<Usuarios>();
                throw;
            }
            return listUsuarios;
        }
        public void UpdateUsuarios(Usuarios usuarios)
        {
            int resultado;
            string procedure = "UpdateUsuarios";
            try
            {
                var parametro = new { UsrId = usuarios.Id, UsrUsuario = usuarios.Usuario, UsrPassword = usuarios.Password, UsrNombres = usuarios.Nombres, UsrApellidos = usuarios.Apellidos, UsrFechaModificacion = DateTime.Now, UsrUsuarioModificacion = usuarios.UsuarioModificacion};
                SqlConnection connection = new SqlConnection(constring);
                connection.Query<string>(procedure, parametro, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
