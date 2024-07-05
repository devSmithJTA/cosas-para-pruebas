using Business;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class DetalleProcesoProveedorController : Controller
    {
        string? IdUsuario = "0";
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DetalleProcesoProveedor(DetalleProcesoProveedor detalleProcesoProveedor)
        {
            string cadena = Config.GetConString();
            DetalleProcesoProveedorManager manager = new DetalleProcesoProveedorManager(cadena);
            DetalleProcesoProveedor detalleProceso = new DetalleProcesoProveedor();
            if (detalleProceso == null)
            {

                detalleProceso = manager.ObtenerDetalleProcesoProveedor(new Data.DetalleProcesoProveedor()).FirstOrDefault();
            }
            else
            {
                detalleProceso = manager.ObtenerDetalleProcesoProveedor(detalleProceso).FirstOrDefault();
            }
            if (detalleProceso == null)
            {
                detalleProceso = new DetalleProcesoProveedor();
            }
            return PartialView(detalleProceso);
        }
        public IActionResult DetalleProcesoProveedorDinamico(Ventas ventas, string procesoDescripcion, string tiposPrendaDescripcion, string telasDescripcion, string adicionDescripcion)
        {
            ventas.adicion.Id = ventas.AdicionId;
            ventas.adicion.Descripcion = adicionDescripcion;
            ventas.proceso.Id = ventas.ProcesoId;
            ventas.proceso.Descripcion = procesoDescripcion;
            ventas.tiposPrenda.Id = ventas.TiposPrendaId;
            ventas.tiposPrenda.Descripcion = tiposPrendaDescripcion;
            ventas.telas.Id = ventas.TelasId;
            ventas.telas.Descripcion = telasDescripcion;
            if (ventas == null)
            {
                ventas = new Ventas();
            }
            return PartialView(ventas);
        }
        public IActionResult ListaVentas()
        {
            string cadena = Config.GetConString();
            List<Ventas> listaVentas = new List<Ventas>();
            VentasManager manager = new VentasManager(cadena);
            listaVentas = manager.listaVentas(new Ventas());
            return PartialView(listaVentas);
        }
    }
}
