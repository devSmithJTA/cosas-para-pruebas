using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace WebApplication2.Controllers
{
    public class ProcesoProveedorController : Controller
    {
        string? IdUsuario = "0";
        public IActionResult Index()
        {
            IdUsuario = HttpContext.Session.GetString("IdUsuario");
            if (IdUsuario == null || IdUsuario == "0")
            {
                return RedirectToAction("Index", "Login");
            }
            else { 
            HttpContext.Session.SetString("IdUsuario",IdUsuario);
            string cadena = Config.GetConString();
            TipoProcesoProveedorManager manager = new TipoProcesoProveedorManager(cadena);
            ViewBag.tipoProcesoProveedor = manager.ObtenerTipoProcesoProveedor(new TipoProcesoProveedor());
            return View();
            }
        }
        public IActionResult ListaProcesoProveedor()
        {
            string cadena = Config.GetConString();
            List<ProcesoProveedor> listaProcesoProveedor = new List<ProcesoProveedor>();
            ProcesoProveedorManager manager = new ProcesoProveedorManager(cadena);
            listaProcesoProveedor = manager.ObtenerProcesoProveedor(new ProcesoProveedor());
            return PartialView(listaProcesoProveedor);
        }
        public IActionResult DetalleProcesoProveedor(ProcesoProveedor procesoProveedor)
        {
            decimal? precioTotal = procesoProveedor.PrecioTotal;
            string cadena = Config.GetConString();
            ProcesoProveedorManager manager = new ProcesoProveedorManager(cadena);
            if (procesoProveedor == null || procesoProveedor.Id==0)
            {
                procesoProveedor = new ProcesoProveedor();
                procesoProveedor.PrecioTotal = precioTotal;
            }
            else
            {
                procesoProveedor = manager.GetProcesoProveedor(procesoProveedor).FirstOrDefault();
            }
            return PartialView(procesoProveedor);
        }

        //CÓDIGO FACTURA
        public IActionResult MostrarProcesoProveedor(int idFactura)
        {
            ProcesoProveedor procesoProveedor = new ProcesoProveedor();
            string cadena = Config.GetConString();
            ProcesoProveedorManager manager = new ProcesoProveedorManager(cadena);
            procesoProveedor = manager.ObtenerProcesoProveedor(new ProcesoProveedor() {Id = idFactura}).FirstOrDefault();
            if (procesoProveedor == null)
            {
                procesoProveedor = new ProcesoProveedor();
            }
            return PartialView(procesoProveedor);
        }

        public int GuardarProcesoProveedor(ProcesoProveedor procesoProveedor, List<DetalleProcesoProveedor> listDetalle)
        {
            IdUsuario = HttpContext.Session.GetString("IdUsuario");
            int idProcesoProveedor = new int();
            string cadena = Config.GetConString();
            DetalleProcesoProveedorManager detalleProcesoProveedorManager = new DetalleProcesoProveedorManager(cadena);
            ProcesoProveedorManager procesoProveedorManager = new ProcesoProveedorManager(cadena);
            procesoProveedor.UsrIdCreo = Convert.ToInt16(IdUsuario);
            idProcesoProveedor = procesoProveedorManager.InsertarProcesoProveedor(procesoProveedor);
            if (!String.IsNullOrEmpty(idProcesoProveedor.ToString()))
            {
                foreach (Data.DetalleProcesoProveedor detalleProcesoProveedor  in listDetalle)
                {
                    detalleProcesoProveedor.UsrIdCreo= Convert.ToInt16(IdUsuario);
                    detalleProcesoProveedor.ProcesoProveedorId = idProcesoProveedor;
                    detalleProcesoProveedor.UsrIdCreo = 1;
                    detalleProcesoProveedorManager.InserartDetalleProcesoProveedor(detalleProcesoProveedor);
                    }
                }
            return idProcesoProveedor;
        }
    }
}
