using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        string? IdUsuario = "0";
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult IniciarSesion(string Usuario, string Password)
        {
            string Result = "OK";
            string cadenaConexion = Config.GetConString();
            UsuariosManager negocio = new UsuariosManager(cadenaConexion);
            Usuarios Usr = new Usuarios();
            Usr.Usuario = Usuario.ToLower();
            Usr.Password = Business.SecurityManager.Encrypt(Password);
            Usuarios Datos = negocio.ObtenerUsuarios(Usr).FirstOrDefault();
            if (Datos == null)
            {
                Result = "NO EXISTE";
            }
            else if (Datos.Estado == false)
            {
                Result = "NO EXISTE";

            }
            else
            {
                string? IdUsuario = Datos.Id.ToString();
                if (IdUsuario == null) { IdUsuario = "0"; }
                HttpContext.Session.SetString("IdUsuario", IdUsuario);
                TempData["IdUsuario"] = IdUsuario;
            }
            return Json(Result);
        }
    }
}
