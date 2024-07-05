using Business;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class UsuariosController : Controller
    {
        string? IdUsuario = "0";
        public IActionResult Index()
        {
            IdUsuario = HttpContext.Session.GetString("IdUsuario");
            if (IdUsuario == null || IdUsuario == "0")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                HttpContext.Session.SetString("IdUsuario", IdUsuario);
                string cadena = Config.GetConString();
                TipoIdentificacionManager Manager = new TipoIdentificacionManager(cadena);
                ViewBag.TipoIdentificacion = Manager.GetTipoIdentificacion(new TipoIdentificacion());
                return View();
            }
        }
        public IActionResult ListarUsuario()
        {
            string cadenaconexion = Config.GetConString();
            UsuariosManager manager = new UsuariosManager(cadenaconexion);
            return PartialView(manager.ObtenerUsuarios(new Usuarios()));
        }
        public IActionResult DetalleUsuario(Usuarios usuarios)
        {
            string cadenaconexion = Config.GetConString();
            Usuarios usuario = new Usuarios();
            UsuariosManager manager = new UsuariosManager(cadenaconexion);
            if (usuarios == null || usuarios.Id == 0)
            {
                usuario = new Usuarios();
            }
            else
            {
                usuario = manager.GetUsuarios(usuarios).FirstOrDefault();
            }
            if (usuario == null)
            {
                usuario = new Usuarios();
            }
            return PartialView(usuario);
        }
        public JsonResult GuardarUsuarios(Usuarios usuarios)
        {
            IdUsuario = HttpContext.Session.GetString("IdUsuario");
            int resultado = new int();
            string cadena = Config.GetConString();
            UsuariosManager Manager = new UsuariosManager(cadena);
            if (String.IsNullOrEmpty(usuarios.Id.ToString()))
            {
                usuarios.UsuarioCreacion = Convert.ToInt16(IdUsuario);
                usuarios.UsuarioModificacion = Convert.ToInt16(IdUsuario);
                usuarios.Password = Business.SecurityManager.Encrypt(usuarios.Password);
                usuarios.Estado = true;
                resultado = Manager.GuardarUsuarios(usuarios);
            }
            else
            {
                usuarios.UsuarioModificacion = Convert.ToInt16(IdUsuario);
                usuarios.Password = Business.SecurityManager.Encrypt(usuarios.Password);
                Manager.UpdateUsuarios(usuarios);
                resultado = (int)usuarios.Id;
            }
            return Json(resultado);
        }
    }
}
