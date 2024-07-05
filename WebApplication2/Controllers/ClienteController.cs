using Business;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ClienteController : Controller
    {
        string? IdUsuario = "0";
        private readonly IWebHostEnvironment _environment;
        public ClienteController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
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
        public IActionResult DetalleCliente(Cliente clientes)
        {
            string cadena = Config.GetConString();
            ClienteManager Mannager = new ClienteManager(cadena);
            Cliente cliente = new Cliente();
            if (clientes == null)
            {
                cliente = Mannager.ListaClientes(new Cliente()).FirstOrDefault();
            }
            else
            {
                cliente = Mannager.ListaClientes(clientes).FirstOrDefault();
            }
            if (cliente == null)
            {
                cliente = new Cliente();
            }
            return View(cliente);
        }
        public JsonResult GuardarCliente(Cliente cliente)
        {
            IdUsuario = HttpContext.Session.GetString("IdUsuario");
            int resultado = new int();
            string cadena = Config.GetConString();
            ClienteManager Manager = new ClienteManager(cadena);
            if (String.IsNullOrEmpty(cliente.Id.ToString()))
            {
                cliente.UsrIdCreo = Convert.ToInt16(IdUsuario);
                resultado = Manager.InsertarCliente(cliente);
            }
            else
            {
                Manager.ActualizarCliente(cliente);
                resultado = (int)cliente.Id;
            }
            return Json(resultado);
        }
        public IActionResult ListaClientes()
        {
            string cadena = Config.GetConString();
            List<Cliente> listaCliente = new List<Cliente>();
            ClienteManager manager = new ClienteManager(cadena);
            listaCliente = manager.ListaClientes(new Cliente());
            return PartialView(listaCliente);
        }
        public string Capturar()
        {
            Cliente cliente = new Cliente();
            int idCliente = 0;
            string cadena = "";
            cadena = Config.GetConString();
            ClienteManager manager = new ClienteManager(cadena);
            string rutaArchivo = "";
            try
            {
                idCliente = manager.ConteoCliente();
                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = file.FileName;
                            var fileExtension = Path.GetExtension(fileName);
                            var newName = "Cliente_" + idCliente + fileExtension;
                            var filepath = Path.Combine(_environment.WebRootPath, "ImagenesCliente") + "\\" + newName;
                            if (!String.IsNullOrEmpty(filepath))
                            {
                                AlmacenarFoto(file, filepath);
                            }
                            cliente = manager.GetCliente(new Cliente() { Id = Convert.ToInt16(idCliente) }).FirstOrDefault();
                            string filepath2 = "";
                            int index = filepath.IndexOf("ImagenesCliente");
                            filepath2 = filepath.Substring(index);
                            filepath2 = filepath2.Replace("\\", "/");
                            cliente.RutaFoto = filepath2;
                            manager.ActualizarCliente(cliente);
                            var imageBytes = System.IO.File.ReadAllBytes(filepath);
                            if (imageBytes != null)
                            {
                                rutaArchivo = filepath;
                            }
                        }
                    }
                }
                return rutaArchivo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AlmacenarFoto(IFormFile file, string filename)
        {
            using (FileStream fs = System.IO.File.Create(filename))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
    }
}
