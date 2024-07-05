using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsuariosManager:UsuariosData
    {
        public UsuariosManager(string constring):base(constring)
        { }
        public int GuardarUsuarios(Usuarios usuarios)
        {
            return InsertUsuarios(usuarios);
        }
        public List<Usuarios> ObtenerUsuarios(Usuarios usuarios)
        {
            return GetUsuarios(usuarios);
        }
    }
}
